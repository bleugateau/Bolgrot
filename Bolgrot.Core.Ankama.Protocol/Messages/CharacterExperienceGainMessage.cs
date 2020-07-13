using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class CharacterExperienceGainMessage : NetworkMessage
    {

	    public int experienceCharacter;
	    public int experienceMount;
	    public int experienceGuild;
	    public int experienceIncarnation;


        public CharacterExperienceGainMessage()
        {
        }

        public CharacterExperienceGainMessage(int experienceCharacter, int experienceMount, int experienceGuild, int experienceIncarnation)
        {
            this.experienceCharacter = experienceCharacter;
            this.experienceMount = experienceMount;
            this.experienceGuild = experienceGuild;
            this.experienceIncarnation = experienceIncarnation;

        }
    }
}