using System.Collections.Generic;
using System.Threading;
using DabScheduleNotifier.Listeners;

namespace DabScheduleNotifier
{
    public class BroadcastWatcher
    {
        private readonly IStationSchedule _schedule;
        private readonly IEnumerable<IBroadcastListener> _broadcastListeners;
        private Broadcast _lastKnownBroadcast;

        public BroadcastWatcher(IStationSchedule schedule, IEnumerable<IBroadcastListener> broadcastListeners)
        {
            _schedule = schedule;
            _broadcastListeners = broadcastListeners;
        }

        public void Watch()
         {
             while (true)
             {
                 var currentBroadcast = _schedule.GetCurrentBroadcast();
                 if (_lastKnownBroadcast != currentBroadcast)
                 {
                     _lastKnownBroadcast = currentBroadcast;
                     NotifyListeners();
                 }
                 
                 Thread.Sleep(10000); // obviously change depending on required time resolution of information
             }
         }

        private void NotifyListeners()
        {
            foreach (var listener in _broadcastListeners)
            {
                listener.NewBroadcastStarted(_lastKnownBroadcast);
            }
        }
    }
}