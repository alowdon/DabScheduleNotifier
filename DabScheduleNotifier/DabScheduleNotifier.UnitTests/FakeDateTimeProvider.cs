using System;

namespace DabScheduleNotifier.UnitTests
{
    public class FakeDateTimeProvider : IDateTimeProvider
    {
        private readonly DateTime _currentDateTime;

        public FakeDateTimeProvider(DateTime currentDateTime)
        {
            _currentDateTime = currentDateTime;
        }

        public DateTime GetCurrentDateTime()
        {
            return _currentDateTime;
        }
    }
}