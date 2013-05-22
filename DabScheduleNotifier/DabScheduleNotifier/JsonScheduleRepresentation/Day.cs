using System;
using System.Collections.Generic;

namespace DabScheduleNotifier.JsonScheduleRepresentation
{
    public class Day
    {
        public DateTime date { get; set; }
        public int has_next { get; set; }
        public int has_previous { get; set; }
        public List<Broadcast> broadcasts { get; set; }
    }
}