using System;

namespace DabScheduleNotifier.Exceptions
{
    [Serializable]
    public class FeedLoadException : Exception
    {
        public FeedLoadException(string feedUrl, Exception innerException)
            : base("Could not load the specified feed: " + feedUrl, innerException)
        {
        }
    }
}