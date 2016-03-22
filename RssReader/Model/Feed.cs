using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.Model
{
    public class Feed
    {
        private string title;
        private string uri;
        private string description;
        //public DateTime date;
        private List<Item> items;

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Uri
        {
            get
            {
                return uri;
            }

            set
            {
                uri = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public List<Item> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
            }
        }
    }
}
