using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class IdentificationSuccessMessage : NetworkMessage
    {

	    public string login;
	    public string nickname;
	    public long accountId;
	    public int communityId;
	    public bool hasRights;
	    public string secretQuestion;
	    public long subscriptionEndDate;
	    public bool wasAlreadyConnected;
	    public long accountCreation;
	    public bool hasConsoleRight;
	    public string _groupFlags;
	    public string _applicationName;


        public IdentificationSuccessMessage()
        {
        }

        public IdentificationSuccessMessage(string login, string nickname, long accountId, int communityId, bool hasRights, string secretQuestion, long subscriptionEndDate, bool wasAlreadyConnected, long accountCreation, bool hasConsoleRight, string _groupFlags, string _applicationName)
        {
            this.login = login;
            this.nickname = nickname;
            this.accountId = accountId;
            this.communityId = communityId;
            this.hasRights = hasRights;
            this.secretQuestion = secretQuestion;
            this.subscriptionEndDate = subscriptionEndDate;
            this.wasAlreadyConnected = wasAlreadyConnected;
            this.accountCreation = accountCreation;
            this.hasConsoleRight = hasConsoleRight;
            this._groupFlags = _groupFlags;
            this._applicationName = _applicationName;

        }
    }
}