using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class AchievementAccount
    {

	    public int id;
	    public bool isFirstForAccount;


        public string _type = "AchievementAccount";

        public AchievementAccount()
        {
        }

        public AchievementAccount(int id, bool isFirstForAccount)
        {
            this.id = id;
            this.isFirstForAccount = isFirstForAccount;

        }
    }
}