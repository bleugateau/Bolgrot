using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class CharacterLevelUpInformationMessage : NetworkMessage
    {

	    public int newLevel;
	    public string name;
	    public int id;


        public CharacterLevelUpInformationMessage()
        {
        }

        public CharacterLevelUpInformationMessage(int newLevel, string name, int id)
        {
            this.newLevel = newLevel;
            this.name = name;
            this.id = id;

        }
    }
}