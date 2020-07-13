using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class CharacterCapabilitiesMessage : NetworkMessage
    {

	    public int guildEmblemSymbolCategories;


        public CharacterCapabilitiesMessage()
        {
        }

        public CharacterCapabilitiesMessage(int guildEmblemSymbolCategories)
        {
            this.guildEmblemSymbolCategories = guildEmblemSymbolCategories;

        }
    }
}