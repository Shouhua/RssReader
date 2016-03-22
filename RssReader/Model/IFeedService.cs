using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.Model
{
    interface IFeedService
    {
        SyndicationFeed GetSyndicationFeed(string uri);
        Feed GetFeed(SyndicationFeed syndicationFeed);
    }
}
