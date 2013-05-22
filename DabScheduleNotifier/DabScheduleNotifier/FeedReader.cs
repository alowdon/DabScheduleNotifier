using System;
using System.IO;
using System.Net;
using DabScheduleNotifier.Exceptions;

namespace DabScheduleNotifier
{
    public class FeedReader
    {
        private readonly string _feedUrl;

        public FeedReader(string feedUrl)
        {
            _feedUrl = feedUrl;
        }

        public string GetFeedText()
        {
            try
            {
                var request = WebRequest.Create(_feedUrl);

                string text;
                var response = (HttpWebResponse) request.GetResponse();

                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                }

                return text;
            }
            catch (Exception e)
            {
                throw new FeedLoadException(_feedUrl, e);
            }
        }
    }
}