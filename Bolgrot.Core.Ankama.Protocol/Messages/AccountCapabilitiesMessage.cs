using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class AccountCapabilitiesMessage : NetworkMessage
    {

	    public int accountId;
	    public bool tutorialAvailable;
	    public int breedsVisible;
	    public int breedsAvailable;
	    public int status;
	    public int[] accountRights;
	    public object _accountRightsMap;


        public AccountCapabilitiesMessage()
        {
        }

        public AccountCapabilitiesMessage(int accountId, bool tutorialAvailable, int breedsVisible, int breedsAvailable, int status, int[] accountRights, object _accountRightsMap)
        {
            this.accountId = accountId;
            this.tutorialAvailable = tutorialAvailable;
            this.breedsVisible = breedsVisible;
            this.breedsAvailable = breedsAvailable;
            this.status = status;
            this.accountRights = accountRights;
            this._accountRightsMap = _accountRightsMap;

        }
    }
}