using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bolgrot.Core.Common.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bolgrot.Core.Common.Managers.Frames
{
    public static class FrameIntercepterManager
    {
        private static List<FrameMethodCallback> frames = new List<FrameMethodCallback>();
        private static List<FrameMethodCallback> callsHandlers = new List<FrameMethodCallback>();
        private static Dictionary<string, Type> messages = new Dictionary<string, Type>();
        private static bool isInitialized = false;

        private static void Initialize()
        {
            if (isInitialized)
            {
                throw new Exception("PacketIntercepter already initialized");
            }

            Assembly assembly = Assembly.GetEntryAssembly();
            //initialize InterceptFrame methods
            foreach (var type in assembly.GetTypes()
                .SelectMany(x => x.GetMethods())
                .Where(method => method.GetCustomAttributes(typeof(InterceptFrame), false).Length != 0 || method.GetCustomAttributes(typeof(InterceptCall), false).Length != 0).ToList())
            {

                if (type.GetCustomAttributes(typeof(InterceptFrame), true).Length != 0)
                {
                    InterceptFrame attr = (InterceptFrame)type.GetCustomAttributes(typeof(InterceptFrame), true)[0];


                    var frameInstance =
                        Activator.CreateInstance(assembly.GetName().Name, type.DeclaringType.FullName); // instance d'une methode
                    frames.Add(new FrameMethodCallback(frameInstance.Unwrap(), attr.MessageType, type));
                }
                else if(type.GetCustomAttributes(typeof(InterceptCall), true).Length != 0)
                {
                    InterceptCall attr = (InterceptCall)type.GetCustomAttributes(typeof(InterceptCall), true)[0];


                    var callInstance =
                        Activator.CreateInstance(assembly.GetName().Name, type.DeclaringType.FullName); // instance d'une methode
                    callsHandlers.Add(new FrameMethodCallback(callInstance.Unwrap(), attr.CallType, type));
                }
                
            }
            
            //initialize NetworkMessage
            LoadNetworkMessage();

            isInitialized = true;
        }

        private static void LoadNetworkMessage()
        {
            Assembly assembly = Assembly.LoadFrom("Bolgrot.Core.Ankama.Protocol.dll");

            foreach (var type in assembly.GetTypes()
                .Where(x => x.BaseType != null && x.BaseType.Name == "CallNetworkMessage").ToArray())
            {
                object objInstance = Activator.CreateInstance(type);
                if (messages.ContainsKey(type.Name.ToString()))
                    continue;

                messages.Add(type.Name.ToString(), objInstance.GetType());
            }
        }
        
        public static void Intercept(Client client, string messageData)
        {
            if (!isInitialized)
            {
                Initialize();
            }

            try
            {
                var message = JsonConvert.DeserializeObject<JObject>(messageData);

                if(message.TryGetValue("call", out JToken callType))
                {
                    switch(callType.ToString())
                    {
                        case "sendMessage":
                            if (!message.TryGetValue("data", out JToken data))
                                return;

                            if (data.Children().FirstOrDefault(x => x.ToString().StartsWith("\"type\"")) == null)
                                return;

                            Console.WriteLine("{0} message intercepted", data["type"].ToString());


                            if (!messages.TryGetValue(data["type"].ToString(), out Type messageType))
                            {
                                Console.WriteLine("{0} unknow message type", data["type"].ToString());
                                return;
                            }

                            var frame = frames.FirstOrDefault(x => x.MessageType == data["type"].ToString());
                            if (frame == null)
                                return;


                            var messageContent = data.ToString();
                            if(data.Children().FirstOrDefault(x => x.ToString().StartsWith("\"data\"")) != null)
                            {
                                messageContent = data["data"].ToString();
                            }


                            frame.Method.Invoke(frame.Instance, new object[] { client, JsonConvert.DeserializeObject(messageContent, messageType) });
                            break;
                        default:
                            
                            Console.WriteLine($"{callType} call intercepted");
                            
                            var call = callsHandlers.FirstOrDefault(x => x.MessageType == callType.ToString());
                            if (call == null)
                                return;

                            call.Method.Invoke(call.Instance, new object[] { client, message });

                            break;
                    }
                }

            }
            catch(Exception ex)
            {
                //client.Dispose();
            }
        }
        
    }
}