using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class InteractiveUsedMessage : NetworkMessage
    {

	    public int entityId;
	    public int elemId;
	    public int skillId;
	    public int duration;
	    public string _useAnimation;


        public InteractiveUsedMessage()
        {
        }

        public InteractiveUsedMessage(int entityId, int elemId, int skillId, int duration, string _useAnimation)
        {
            this.entityId = entityId;
            this.elemId = elemId;
            this.skillId = skillId;
            this.duration = duration;
            this._useAnimation = _useAnimation;

        }
    }
}