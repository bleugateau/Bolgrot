using System;

namespace Bolgrot.Core.Common.Managers.Frames
{
    public class InterceptFrame : Attribute
    {
        public string MessageType { get; }

        public InterceptFrame(string messageType)
        {
            this.MessageType = messageType;
        }
    }
}