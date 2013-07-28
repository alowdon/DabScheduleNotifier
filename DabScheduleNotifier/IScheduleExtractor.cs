using System.Collections.Generic;

namespace DabScheduleNotifier
{
    public interface IScheduleExtractor
    {
        IEnumerable<Broadcast> Extract(string feedText);
    }
}