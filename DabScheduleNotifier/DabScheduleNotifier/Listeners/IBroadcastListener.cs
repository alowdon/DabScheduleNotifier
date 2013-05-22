namespace DabScheduleNotifier.Listeners
{
    public interface IBroadcastListener
    {
        void NewBroadcastStarted(Broadcast broadcast);
    }
}