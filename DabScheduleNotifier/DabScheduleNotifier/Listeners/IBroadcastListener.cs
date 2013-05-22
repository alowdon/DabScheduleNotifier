namespace DabScheduleNotifier.Listeners
{
    public interface IBroadcastListener
    {
        // could alternatively use EventHandlers to achieve this

        void NewBroadcastStarted(Broadcast broadcast);
    }
}