using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ServerExperienceModificatorMessage : NetworkMessage
    {

	    public int experiencePercent;


        public ServerExperienceModificatorMessage()
        {
        }

        public ServerExperienceModificatorMessage(int experiencePercent)
        {
            this.experiencePercent = experiencePercent;

        }
    }
}