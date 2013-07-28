using System;

namespace DabScheduleNotifier
{
    public class Broadcast : IEquatable<Broadcast>
    {
        public string Id { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string DisplayTitle { get; private set; }
        public string DisplaySubtitle { get; private set; }

        public Broadcast(string id, DateTime startTime, DateTime endTime, string displayTitle, string displaySubtitle)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            DisplayTitle = displayTitle;
            DisplaySubtitle = displaySubtitle;
        }

        public bool Equals(Broadcast other)
        {
            if (other == null) return false;

            return Id == other.Id;
        }
    }
}