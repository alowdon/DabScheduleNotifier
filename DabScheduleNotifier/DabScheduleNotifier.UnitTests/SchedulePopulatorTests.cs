using System.IO;
using System.Linq;
using NUnit.Framework;

namespace DabScheduleNotifier.UnitTests
{
    [TestFixture]
    public class SchedulePopulatorTests
    {
        private string _exampleFeed;

        [TestFixtureSetUp]
        public void LoadFeed()
        {
            _exampleFeed = File.ReadAllText(@"TestData\examplefeed.json");
        }

        [Test]
        public void CanPopulateSchedule()
        {
            var schedule = new SchedulePopulator().ExtractSchedule(_exampleFeed);

            Assert.IsNotNull(schedule);
            Assert.IsTrue(schedule.Any());
        }
    }
}