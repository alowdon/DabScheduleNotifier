namespace DabScheduleNotifier
{
    public class BroadcastFormatter : IBroadcastFormatter
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public BroadcastFormatter()
            : this(new DateTimeProvider())
        {
        }

        public BroadcastFormatter(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public string Format(Broadcast broadcast)
        {
            return string.Format(
                "{0:dd/MM/yyyy HH:mm}\tScheduled start: {1:dd/MM/yyyy HH:mm}\t{2}: {3} ({4})",
                _dateTimeProvider.GetCurrentDateTime(),
                broadcast.StartTime,
                broadcast.Id,
                broadcast.DisplayTitle,
                broadcast.DisplaySubtitle);
        }
    }
}