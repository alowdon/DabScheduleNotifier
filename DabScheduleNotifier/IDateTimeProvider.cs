using System;

namespace DabScheduleNotifier
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentDateTime();
    }
}