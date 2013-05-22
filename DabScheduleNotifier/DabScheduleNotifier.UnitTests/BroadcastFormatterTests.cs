using System;
using NUnit.Framework;

namespace DabScheduleNotifier.UnitTests
{
    [TestFixture]
    public class BroadcastFormatterTests
    {
        [Test]
        public void CanFormatBroadcastData()
        {
            var formatter = new BroadcastFormatter(new FakeDateTimeProvider(new DateTime(2013, 03, 04, 12, 04, 00)));
            var broadcast = new Broadcast("1", new DateTime(2013, 02, 03, 12, 00, 00), new DateTime(2013, 02, 03, 14, 00, 00), "Title 1", "Subtitle 1");

            var formattedString = formatter.Format(broadcast);
            Assert.AreEqual("04/03/2013 12:04	Scheduled start: 03/02/2013 12:00	1: Title 1 (Subtitle 1)", formattedString);
        }
    }
}