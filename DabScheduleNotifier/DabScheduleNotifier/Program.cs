using DabScheduleNotifier.Listeners;

namespace DabScheduleNotifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var feedUrl = args[0];
            var outputFile = args[1];

            var feed = new JsonFeedReader(feedUrl).GetFeedText();
            var scheduleDetails = new ScheduleExtractor().Extract(feed);

            var stationSchedule = new StationSchedule();
            stationSchedule.PopulateSchedule(scheduleDetails);

            new BroadcastWatcher(stationSchedule, 10, new ConsoleBroadcastListener(), new FileBroadcastListener(outputFile)).Watch();
        }
    }
}
