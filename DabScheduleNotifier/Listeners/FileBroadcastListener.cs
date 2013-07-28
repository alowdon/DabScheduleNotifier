using System;
using System.IO;

namespace DabScheduleNotifier.Listeners
{
    public class FileBroadcastListener : IBroadcastListener
    {
        private readonly string _fileName;
        private readonly IBroadcastFormatter _broadcastFormatter;

        public FileBroadcastListener(string fileName)
            : this(new BroadcastFormatter())
        {
            _fileName = fileName;
        }

        public FileBroadcastListener(IBroadcastFormatter broadcastFormatter)
        {
            _broadcastFormatter = broadcastFormatter;
        }

        public void NewBroadcastStarted(Broadcast broadcast)
        {
            var broadcastDetails = _broadcastFormatter.Format(broadcast);

            File.AppendAllText(_fileName, broadcastDetails + Environment.NewLine);
        }
    }
}