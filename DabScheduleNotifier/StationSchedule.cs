using System;
using System.Collections.Generic;
using System.Linq;

namespace DabScheduleNotifier
{
    public class StationSchedule : IStationSchedule
    {
        private readonly List<Broadcast> _broadcasts;
        private readonly IDateTimeProvider _dateTimeProvider;

        public StationSchedule() : this(new DateTimeProvider())
        {
        }

        public StationSchedule(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
            _broadcasts = new List<Broadcast>();
        }

        public void PopulateSchedule(IEnumerable<Broadcast> broadcasts)
        {
            _broadcasts.Clear();
            var orderedBroadcasts = broadcasts.OrderBy(b => b.StartTime).ToList();

            _broadcasts.AddRange(orderedBroadcasts.Where(b => b.EndTime > _dateTimeProvider.GetCurrentDateTime())); // only add those broadcasts which are yet to happen
        }

        public Broadcast GetCurrentBroadcast()
        {
            var currentTime = _dateTimeProvider.GetCurrentDateTime();
            
            RemovePastBroadcasts(currentTime);

            var nextBroadcast = _broadcasts.FirstOrDefault();

            if (nextBroadcast == null || nextBroadcast.StartTime > currentTime) return null;

            return nextBroadcast;
        }

        private void RemovePastBroadcasts(DateTime currentTime)
        {
            var broadcast = _broadcasts.FirstOrDefault();

            while (broadcast != null && broadcast.EndTime < currentTime)
            {
                _broadcasts.Remove(broadcast);
                broadcast = _broadcasts.FirstOrDefault();
            }
        }
    }
}