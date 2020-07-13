using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class SetUpdateMessage : NetworkMessage
    {

	    public int setId;
	    public int[] setObjects;
	    public ObjectEffectInteger[] setEffects;


        public SetUpdateMessage()
        {
        }

        public SetUpdateMessage(int setId, int[] setObjects, ObjectEffectInteger[] setEffects)
        {
            this.setId = setId;
            this.setObjects = setObjects;
            this.setEffects = setEffects;

        }
    }
}