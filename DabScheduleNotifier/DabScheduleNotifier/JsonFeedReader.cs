using System.IO;
using System.Net;

namespace DabScheduleNotifier
{
    public class JsonFeedReader
    {
        private readonly string _feedUrl;

        public JsonFeedReader(string feedUrl)
        {
            _feedUrl = feedUrl;
        }

        public string GetFeed()
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
    }
}