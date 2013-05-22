using System.Collections.Generic;

namespace DabScheduleNotifier
{
    public interface IStationSchedule
    {
        void PopulateSchedule(IEnumerable<Broadcast> broadcasts);
        Broadcast GetCurrentBroadcast();
    }
}