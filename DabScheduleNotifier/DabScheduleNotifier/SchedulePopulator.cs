using System.Collections.Generic;
using System.Linq;
using DabScheduleNotifier.JsonScheduleRepresentation;
using Newtonsoft.Json;

namespace DabScheduleNotifier
{
    public class SchedulePopulator
    {
         public IEnumerable<ScheduleItem> ExtractSchedule(string feed)
         {
             var options = new JsonSerializerSettings
                               {
                                   CheckAdditionalContent = false,
                                   MissingMemberHandling = MissingMemberHandling.Ignore
                               };

             var scheduleFeed = JsonConvert.DeserializeObject<ScheduleFeed>(feed, options);

             return scheduleFeed.schedule.day.broadcasts.Select(b =>
                     new ScheduleItem(b.programme.pid, b.start, b.end, b.programme.display_titles.title, b.programme.display_titles.subtitle));
         }
    }
}