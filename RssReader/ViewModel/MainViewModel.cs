using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RssReader.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using System;

namespace RssReader.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        private  ObservableCollection<News> _newsSource;
        public ObservableCollection<News> NewsSource
        {
            get
            {
                if(_newsSource == null)
                {
                    News news = new News("163 News", "http://news.163.com/special/00011K6L/rss_newstop.xml");
                    _newsSource = new ObservableCollection<News>();
                    _newsSource.Add(news);
                    _newsSource.Add(new News("Sohu News", "http://rss.news.sohu.com/rss/focus.xml"));
                    _newsSource.Add(new News("Sina News", "http://rss.sina.com.cn/news/china/focus15.xml"));
                }
                return _newsSource;
            }
        }

        private RelayCommand<string> _getNews;
        public RelayCommand<string> GetNews
        {
            get
            {
                if(_getNews == null)
                {
                    _getNews = new RelayCommand<string>(uri => this.RequestNews(uri));
                }
                return _getNews;
            }
        }

        private void RequestNews(string uri)
        {
            FeedService fs = new FeedService();
            SyndicationFeed sf =  fs.GetSyndicationFeed(uri);
            Feed feed = fs.GetFeed(sf);
            foreach(Item item in feed.Items)
            {
                _newsTitles.Add(item);
            }
        }

        private ObservableCollection<Item> _newsTitles = new ObservableCollection<Item>();
        public ObservableCollection<Item> NewsTitles
        {
            get
            {
                return _newsTitles;
            }
        }

        private ObservableCollection<Item> _newsDescription = new ObservableCollection<Item>();
        public ObservableCollection<Item> NewsDescription
        {
            get
            {
                return _newsDescription;
            }
        }

        private RelayCommand<string> _selectNews;
        public RelayCommand<string> SelectNews
        {
            get
            {
                if (_selectNews == null)
                {
                    _selectNews = new RelayCommand<string>(des => this.RequestDescription(des));
                }
                return _selectNews;
            }
        }

        private void RequestDescription(string des)
        {
            System.Console.WriteLine(des);
        }
    }
}