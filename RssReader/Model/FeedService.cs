using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RssReader.Model
{
    public class FeedService : IFeedService
    {
        private SyndicationFeed _syndicationFeed;
        private Feed _feed = new Feed();
        private List<Item> _items = new List<Item>();

        public FeedService() { }

        public SyndicationFeed GetSyndicationFeed(string uri)
        {
            try
            {
                XmlReader reader = MyXmlReader.Create(uri);
                _syndicationFeed = SyndicationFeed.Load(reader);
                _feed.Uri = uri;
            }
            catch(ArgumentNullException e)
            {
                System.Console.WriteLine("The Argument Uri Is NULL...");
            }
            catch(Exception e)
            {
                System.Console.WriteLine("XmlReader or Syndication error: {0}", e.Message);
            }
            return _syndicationFeed;
        }

        public Feed GetFeed(SyndicationFeed syndicationFeed)
        {
            _feed.Title = syndicationFeed.Title.Text;
            _feed.Description = syndicationFeed.Description.Text;
            List<SyndicationItem> syndicationItem = syndicationFeed.Items.ToList();
            _feed.Items = new List<Item>();
            foreach(SyndicationItem i in syndicationItem)
            {
                Item item = new Item();
                item.Title = i.Title.Text.Trim();
                item.Description = i.Summary.Text;
                item.Link = i.Id;
                _feed.Items.Add(item);
            }
            //_feed.Items = _items;
            return _feed;
        }
    }
}
