using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class shopOpenCategorySuccess : NetworkMessage
    {

	    public string categoryId;
	    public int page;
	    public int[] articles;
	    public int totalArticles;


        public shopOpenCategorySuccess()
        {
        }

        public shopOpenCategorySuccess(string categoryId, int page, int[] articles, int totalArticles)
        {
            this.categoryId = categoryId;
            this.page = page;
            this.articles = articles;
            this.totalArticles = totalArticles;

        }
    }
}