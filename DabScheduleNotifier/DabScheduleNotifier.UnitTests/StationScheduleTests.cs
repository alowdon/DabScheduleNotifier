using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DabScheduleNotifier.UnitTests
{
    [TestFixture]
    public class StationScheduleTests
    {
        private readonly IEnumerable<Broadcast> _broadcasts = new List<Broadcast>
                                                                  {
                                                                      new Broadcast("1", new DateTime(2012, 1, 2, 10, 00, 00), new DateTime(2012, 1, 2, 11, 00, 00), "Title 1", "Subtitle 1"),
                                                                      new Broadcast("2", new DateTime(2012, 1, 2, 11, 00, 00), new DateTime(2012, 1, 2, 12, 00, 00), "Title 2", "Subtitle 2"),
                                                                      new Broadcast("3", new DateTime(2012, 1, 2, 13, 00, 00), new DateTime(2012, 1, 2, 15, 00, 00), "Title 3", "Subtitle 3"),
                                                                      new Broadcast("4", new DateTime(2012, 1, 2, 15, 00, 00), new DateTime(2012, 1, 2, 18, 00, 00), "Title 4", "Subtitle 4"),
                                                                  };

        [Test]
        public void CanRetrieveCurrentBroadcastFromTopOfSchedule()
        {
            var currentDateTime = new DateTime(2012, 1, 2, 10, 30, 00);
            var stationSchedule = GetStationSchedule(currentDateTime);

            stationSchedule.PopulateSchedule(_broadcasts);
            var currentBroadcast = stationSchedule.GetCurrentBroadcast();

            Assert.IsNotNull(currentBroadcast);
            Assert.AreEqual("1", currentBroadcast.Id);
        }

        [Test]
        public void CanRetrieveCurrentBroadcastFromMiddleOfSchedule()
        {
            var currentDateTime = new DateTime(2012, 1, 2, 14, 00, 00);
            var stationSchedule = GetStationSchedule(currentDateTime);

            stationSchedule.PopulateSchedule(_broadcasts);
            var currentBroadcast = stationSchedule.GetCurrentBroadcast();

            Assert.IsNotNull(currentBroadcast);
            Assert.AreEqual("3", currentBroadcast.Id);
        }

        [Test]
        public void ReturnsNullIfNoCurrentBroadcastAvailable()
        {
            var currentDateTime = new DateTime(2012, 1, 2, 12, 30, 00);
            var stationSchedule = GetStationSchedule(currentDateTime);

            stationSchedule.PopulateSchedule(_broadcasts);
            var currentBroadcast = stationSchedule.GetCurrentBroadcast();

            Assert.IsNull(currentBroadcast);
        }

        [Test]
        public void ReturnsNullIfScheduleHasFinished()
        {
            var currentDateTime = new DateTime(2012, 1, 3, 00, 00, 00);
            var stationSchedule = GetStationSchedule(currentDateTime);

            stationSchedule.PopulateSchedule(_broadcasts);
            var currentBroadcast = stationSchedule.GetCurrentBroadcast();

            Assert.IsNull(currentBroadcast);
        }

        [Test]
        public void CurrentBroadcastIsOneThatStartsAtTheSpecifiedTime()
        {
            var currentDateTime = new DateTime(2012, 1, 2, 11, 00, 00);
            var stationSchedule = GetStationSchedule(currentDateTime);

            stationSchedule.PopulateSchedule(_broadcasts);
            var currentBroadcast = stationSchedule.GetCurrentBroadcast();

            Assert.IsNotNull(currentBroadcast);
            Assert.AreEqual("2", currentBroadcast.Id);
        }

        private static StationSchedule GetStationSchedule(DateTime currentDateTime)
        {
            var stationSchedule = new StationSchedule(new FakeDateTimeProvider(currentDateTime));
            return stationSchedule;
        }

        private class FakeDateTimeProvider : IDateTimeProvider
        {
            private readonly DateTime _currentDateTime;

            public FakeDateTimeProvider(DateTime currentDateTime)
            {
                _currentDateTime = currentDateTime;
            }

            public DateTime GetCurrentDateTime()
            {
                return _currentDateTime;
            }
        }
    }
}