using System;

namespace DabScheduleNotifier.Listeners
{
    public class ConsoleBroadcastListener : IBroadcastListener
    {
        private readonly IBroadcastFormatter _broadcastFormatter;

        public ConsoleBroadcastListener()
            : this(new BroadcastFormatter())
        {
        }

        public ConsoleBroadcastListener(IBroadcastFormatter broadcastFormatter)
        {
            _broadcastFormatter = broadcastFormatter;
        }

        public void NewBroadcastStarted(Broadcast broadcast)
        {
            Console.WriteLine(_broadcastFormatter.Format(broadcast));
        }
    }
}