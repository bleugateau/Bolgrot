using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class CharacterFirstSelectionMessage : CallNetworkMessage
    {

	    public int id;
	    public bool doTutorial;


        public CharacterFirstSelectionMessage()
        {
        }

        public CharacterFirstSelectionMessage(int id, bool doTutorial)
        {
            this.id = id;
            this.doTutorial = doTutorial;

        }
    }
}