using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.Model
{
    public class Item
    {
        private string _title;
        private string _link;
        private string _description;
        //public string category;
        private string _creator;
        private DateTime _date;

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public string Link
        {
            get
            {
                return _link;
            }

            set
            {
                _link = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public string Creator
        {
            get
            {
                return _creator;
            }

            set
            {
               _creator = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }

        public Item(string title, string link, string des, string creator,DateTime datetime)
        {
            _title = title;
            _link = link;
            _description = des;
            _creator = creator;
            _date = datetime;
        }
        public Item() { }
    }
}
