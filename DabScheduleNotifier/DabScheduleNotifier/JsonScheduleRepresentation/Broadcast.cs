using System;

namespace DabScheduleNotifier.JsonScheduleRepresentation
{
    public class Broadcast
    {
        public bool is_repeat { get; set; }
        public bool is_blanked { get; set; }
        public string pid { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int duration { get; set; }
        public Programme programme { get; set; }
    }
}