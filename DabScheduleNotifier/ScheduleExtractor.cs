using System.Collections.Generic;
using System.Linq;
using DabScheduleNotifier.JsonScheduleRepresentation;
using Newtonsoft.Json;

namespace DabScheduleNotifier
{
    public class ScheduleExtractor : IScheduleExtractor
    {
         public IEnumerable<Broadcast> Extract(string feedText)
         {
             var options = new JsonSerializerSettings
                               {
                                   CheckAdditionalContent = false,
                                   MissingMemberHandling = MissingMemberHandling.Ignore
                               };

             try
             {
                 var scheduleFeed = JsonConvert.DeserializeObject<ScheduleFeed>(feedText, options);

                 return scheduleFeed.schedule.day.broadcasts.Select(b =>
                     new Broadcast(b.programme.pid, b.start, b.end, b.programme.display_titles.title, b.programme.display_titles.subtitle));
             }
             catch (JsonSerializationException)
             {
                 // return an empty schedule since we can't get any details
                 return new List<Broadcast>();
             }
         }
    }
}