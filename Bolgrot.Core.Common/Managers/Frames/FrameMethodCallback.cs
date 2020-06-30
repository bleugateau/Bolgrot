using System.Reflection;

namespace Bolgrot.Core.Common.Managers.Frames
{
    public class FrameMethodCallback
    {
        public object Instance { get; set; }

        public string MessageType { get; set; }

        public MethodInfo Method { get; set; }

        public FrameMethodCallback(object instance, string messageType, MethodInfo method)
        {
            this.Instance = instance;
            this.MessageType = messageType;
            this.Method = method;
        }
    }
}