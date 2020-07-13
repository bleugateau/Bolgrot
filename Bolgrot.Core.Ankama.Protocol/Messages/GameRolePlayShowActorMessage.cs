using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameRolePlayShowActorMessage : NetworkMessage
    {

	    public GameRolePlayCharacterInformations informations;


        public GameRolePlayShowActorMessage()
        {
        }

        public GameRolePlayShowActorMessage(GameRolePlayCharacterInformations informations)
        {
            this.informations = informations;

        }
    }
}