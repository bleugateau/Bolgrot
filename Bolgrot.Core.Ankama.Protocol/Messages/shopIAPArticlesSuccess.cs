using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class shopIAPArticlesSuccess : NetworkMessage
    {

	    public int[] articles;


        public shopIAPArticlesSuccess()
        {
        }

        public shopIAPArticlesSuccess(int[] articles)
        {
            this.articles = articles;

        }
    }
}