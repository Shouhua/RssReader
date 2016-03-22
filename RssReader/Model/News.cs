using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.Model
{
    public class News
    {
        string _newsName;
        string _newsUri;

        public string NewsName
        {
            get
            {
                return _newsName;
            }  
        }

        public string NewsUri
        {
            get
            {
                return _newsUri;
            }
        }

        public News(string newsName, string newsUri)
        {
            _newsName = newsName;
            _newsUri = newsUri;
        }
    }
}
