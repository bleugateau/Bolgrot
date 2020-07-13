using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Bolgrot.Tools.MITM.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bolgrot.Tools.MITM
{
    public enum FileType {
        TYPE,
        MESSAGE,
        SENDMESSAGE
    }

    public static class ProtocolBuilderManager
    {

        private static string builtNamespace = "Bolgrot.Core.Ankama.Protocol.";
        private static string messageTemplate = Resources.messageTemplate;
        private static string sendMessageTemplate = Resources.sendMessageTemplate;
        private static string typeTemplate = Resources.typeTemplate;

        private static string savePath = @"./Messages/";
        private static string buildSavePath = @"./Types/";
        private static string sendMessageSavePath = @"./SendMessages/";

        public static void BuildMessage(string messageName, string messageData)
        {
            var messageClassContent = new Regex("([0-9]{0,1}){\"([_messageType]{12})\":(.+)}").Match(messageData);
            var fields = new Regex("(\"[A-Za-z]{1,50}\"),(.+)").Match(messageClassContent.Groups[3].ToString());


            //message already built
            if (File.Exists(savePath + messageName + ".cs"))
                return;

           
            var parsedMessageContent = JObject.Parse("{" +fields.Groups[2].ToString() + "}");


            ParsePacketAndGenerateFile(messageName, "{" + fields.Groups[2].ToString() + "}");
        }

        public static void BuildSendMessage(string messageData)
        {
            var data = JsonConvert.DeserializeObject<JObject>(messageData);

            if (!data.TryGetValue("type", out JToken messageName))
                return;


            if (!data.TryGetValue("data", out JToken messageDataContent))
                return;



            ParsePacketAndGenerateFile(messageName.ToString(), messageDataContent.ToString(), FileType.SENDMESSAGE);



        }

        private static string extractTypeFromFieldValue(string fieldValue)
        {
            var _type = new Regex("(\"_type\":\"[a-zA-Z]{1,}\",){1}").Match(fieldValue);
            var extractedType = new Regex("(\"_type\"):(\"[a-zA-Z]{1,}\")").Match(_type.Groups[1].ToString());


            return extractedType.Groups[2].ToString().Replace("\"", "");
        }

        public static void ParsePacketAndGenerateFile(string className, string jsonData, FileType fileType = FileType.MESSAGE)
        {

            Console.WriteLine("New className {0}.", className);

            string variables = "";
            string constructorArgs = "";
            string constructor = "";

            try
            {
                var parsedObject = JObject.Parse(jsonData);


                bool firstArg = true;


                foreach (var field in parsedObject.Properties())
                {

                    string type = GetValueTypeFromJObjectType(field.Value.Type.ToString());

                    var value = "";

                    switch (field.Value.Type.ToString())
                    {
                        case "Array":
                            value = field.Value.Count() != 0 ? field.Value[0].ToString(Formatting.None, new JsonConverter[0]) : "";

                            if (value.Contains("_type"))
                            {
                                Console.WriteLine(value);


                                type = extractTypeFromFieldValue(value) + "[]";

                                //build type
                                ParsePacketAndGenerateFile(extractTypeFromFieldValue(value), value, FileType.TYPE);
                            }
                            else
                            {
                                type = GetValueTypeFromJObjectType(field.Value.Count() != 0 ? field.Value[0].Type.ToString() : "Integer") + "[]";
                            }
                            break;
                        case "Object":
                            value = field.Value.ToString(Formatting.None, new JsonConverter[0]);
                            if (value.Contains("_type"))
                            {
                                Console.WriteLine(value);
                                type = extractTypeFromFieldValue(value);

                                //build type
                                ParsePacketAndGenerateFile(extractTypeFromFieldValue(value), value, FileType.TYPE);
                            }
                            else
                            {
                                type = "object";
                                //throw new Exception("Error Object parsed !");
                            }
                            break;
                    }



                    if (field.Name == "_type" || field.Name == "_isInitialized")
                    {
                        continue;
                    }

                    Console.WriteLine(type);

                    variables += "	    public " + type + " " + field.Name + ";\n";

                    constructorArgs += (!firstArg ? ", " : "") + type + " " + field.Name;

                    constructor += "            this." + field.Name + " = " + field.Name + ";\n";

                    firstArg = false;
                }
            }
            catch
            {

            }


            switch (fileType)
            {
                case FileType.MESSAGE:
                    GenerateMessage(className, variables, constructorArgs, constructor);
                    break;
                case FileType.TYPE:
                    GenerateType(className, variables, constructorArgs, constructor);
                    break;
                case FileType.SENDMESSAGE:
                    GenerateSendMessage(className, variables, constructorArgs, constructor);
                    break;
            }

        }

        private static void GenerateMessage(string messageName, string variables, string constructorArgs, string constructor)
        {
            StreamWriter writer = new StreamWriter(savePath + messageName + ".cs");
            writer.Write(messageTemplate
                .Replace("%NAMESPACE%", builtNamespace + "Messages")
                .Replace("%MESSAGENAME%", messageName)
                .Replace("%VARIABLES%", variables)
                .Replace("%ARGS%", constructorArgs)
                .Replace("%CONSTRUCTOR%", constructor));


            writer.Close();

            Console.WriteLine("{0} message generated !", messageName);
        }

        private static void GenerateSendMessage(string messageName, string variables, string constructorArgs, string constructor)
        {
            StreamWriter writer = new StreamWriter(sendMessageSavePath + messageName + ".cs");
            writer.Write(sendMessageTemplate
                .Replace("%NAMESPACE%", builtNamespace + "SendMessages")
                .Replace("%MESSAGENAME%", messageName)
                .Replace("%VARIABLES%", variables)
                .Replace("%ARGS%", constructorArgs)
                .Replace("%CONSTRUCTOR%", constructor));


            writer.Close();

            Console.WriteLine("{0} message generated !", messageName);
        }

        private static void GenerateType(string typeName, string variables, string constructorArgs, string constructor)
        {
            StreamWriter writer = new StreamWriter(buildSavePath + typeName + ".cs");
            writer.Write(typeTemplate
                .Replace("%NAMESPACE%", builtNamespace + "Types")
                .Replace("%TYPENAME%", typeName)
                .Replace("%VARIABLES%", variables)
                .Replace("%ARGS%", constructorArgs)
                .Replace("%CONSTRUCTOR%", constructor));


            writer.Close();

            Console.WriteLine("{0} type generated !", typeName);
        }

        private static string GetValueTypeFromJObjectType(string valueType)
        {
            switch(valueType)
            {
                case "Boolean":
                    return "bool";
                case "String":
                    return "string";
                case "Long":
                    return "long";
                case "Integer":
                    return "int";
                case "Object":
                case "Array":
                    return "";
                default:
                    Console.WriteLine("Unknowtype: {0}", valueType);
                    break;
            }

            return "unknowtype";
        }

    }
}