using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class CharacterCreationRequestMessage : CallNetworkMessage
    {

	    public string name;
	    public int breed;
	    public bool sex;
	    public int[] colors;
	    public int cosmeticId;


        public CharacterCreationRequestMessage()
        {
        }

        public CharacterCreationRequestMessage(string name, int breed, bool sex, int[] colors, int cosmeticId)
        {
            this.name = name;
            this.breed = breed;
            this.sex = sex;
            this.colors = colors;
            this.cosmeticId = cosmeticId;

        }
    }
}