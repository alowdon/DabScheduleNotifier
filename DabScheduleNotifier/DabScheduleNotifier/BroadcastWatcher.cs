using System.Collections.Generic;
using System.Threading;
using DabScheduleNotifier.Listeners;

namespace DabScheduleNotifier
{
    public class BroadcastWatcher
    {
        private readonly IStationSchedule _schedule;
        private readonly int _timeout;
        private readonly IEnumerable<IBroadcastListener> _broadcastListeners;
        private Broadcast _lastKnownBroadcast;

        public BroadcastWatcher(IStationSchedule schedule, int timeoutInSeconds, params IBroadcastListener[] broadcastListeners)
        {
            _schedule = schedule;
            _timeout = timeoutInSeconds * 1000;
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

                 Thread.Sleep(_timeout);
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