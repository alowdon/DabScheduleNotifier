using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace DabScheduleNotifier.UnitTests
{
    [TestFixture]
    public class ScheduleExtractorTests
    {
        private string _exampleFeed;

        [TestFixtureSetUp]
        public void LoadFeed()
        {
            _exampleFeed = File.ReadAllText(@"TestData\examplefeed.json");
        }

        [Test]
        public void CanExtractSchedule()
        {
            var schedule = new ScheduleExtractor().Extract(_exampleFeed);

            Assert.IsNotNull(schedule);
            Assert.AreEqual(16, schedule.Count());
        }

        [Test]
        public void CopiesDetailsOfEpisodeFromJsonRepresentation()
        {
            var schedule = new ScheduleExtractor().Extract(_exampleFeed);
            Assert.IsNotNull(schedule);
            
            var firstEpisode = schedule.First();
            Assert.IsNotNull(firstEpisode);
            Assert.AreEqual("b01shqg9", firstEpisode.Id);
            Assert.AreEqual("Janice Long", firstEpisode.DisplayTitle);
            Assert.AreEqual("22/05/2013", firstEpisode.DisplaySubtitle);

            // there's some potential funkiness around datetimes here that I'm going to gloss over for now to hopefully return to later
            Assert.AreEqual(new DateTime(2013, 05, 22, 00, 00, 00, 00), firstEpisode.StartTime);
            Assert.AreEqual(new DateTime(2013, 05, 22, 02, 00, 00, 00), firstEpisode.EndTime);
        }

        [Test]
        public void ReturnsEmptyScheduleIfFeedIsCorrupt()
        {
            var brokenFeedText = File.ReadAllText(@"TestData\brokenfeed.json");
            var schedule = new ScheduleExtractor().Extract(brokenFeedText);

            Assert.IsNotNull(schedule);
            Assert.IsFalse(schedule.Any());
        }
    }
}