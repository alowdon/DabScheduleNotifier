using DabScheduleNotifier;
using DabScheduleNotifier.Exceptions;
using NUnit.Framework;

namespace DabScheduleNotified.IntegrationTests
{
    [TestFixture]
    public class FeedReaderTests
    {
        [Test]
        public void CanRetrieveFeed()
        {
            // would make this a more reliable URL if possible, e.g. one under our control
            var reader = new FeedReader("http://www.bbc.co.uk/radio2/programmes/schedules.xml");
            var feedText = reader.GetFeedText();

            Assert.IsNotNull(feedText);
            Assert.IsTrue(feedText.Contains("BBC Radio 2"));
        }

        [Test]
        public void ThrowsExceptionIfFeedCannotBeFound()
        {
            const string brokenUrl = "http://dummyurl.doesnotexist";

            var reader = new FeedReader(brokenUrl);
            var exception = Assert.Throws<FeedLoadException>(() => reader.GetFeedText());
            Assert.AreEqual("Could not load the specified feed: " + brokenUrl, exception.Message);
        }
    }
}