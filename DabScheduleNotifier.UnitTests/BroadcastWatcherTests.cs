using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DabScheduleNotifier.Listeners;
using NUnit.Framework;

namespace DabScheduleNotifier.UnitTests
{
    [TestFixture]
    public class BroadcastWatcherTests
    {
        [Test]
        public void NotifiesListenerOfCurrentBroadcast()
        {
            var schedule = new FakeStationSchedule();
            var listener = new TestBroadcastListener();

            new BroadcastWatcher(schedule, 1, new TestBroadcastListener()).Watch();
            Thread.Sleep(3);

            var broadcasts = listener.GetBroadcasts();
            Assert.IsTrue(broadcasts.Any());
        }

        private class TestBroadcastListener : IBroadcastListener
        {
            private readonly IList<Broadcast> _broadcasts;

            public TestBroadcastListener()
            {
                _broadcasts = new List<Broadcast>();
            }

            public void NewBroadcastStarted(Broadcast broadcast)
            {
                _broadcasts.Add(broadcast);
            }

            public IEnumerable<Broadcast> GetBroadcasts()
            {
                return _broadcasts;
            }
        }

        private class FakeStationSchedule : IStationSchedule
        {
            private int _currentId;

            public FakeStationSchedule()
            {
                _currentId = 1;
            }

            public void PopulateSchedule(IEnumerable<Broadcast> broadcasts)
            {
            }

            public Broadcast GetCurrentBroadcast()
            {
                var broadcast = new Broadcast(
                    _currentId++.ToString(), 
                    new DateTime(2013, 02, 03, 12, 00, 00), 
                    new DateTime(2013, 02, 03, 14, 00, 00), 
                    "Title 1", 
                    "Subtitle 1");

                return broadcast;
            }
        }
    }
}