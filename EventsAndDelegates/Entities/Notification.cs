namespace EventsAndDelegates.Entities
{
    public class Notification
    {
        // Event without arguments
        public event EventHandler? NotificationConfirmed;

        // Event with arguments
        public event EventHandler<NotificationReceivedEventArgs>? NotificationConfirmedWithArgs;

        // Event with arguments and your own delegate (we are not using the traditional EventHandler from .NET)
        public event NotificationEventHandler? NotificationConfirmedDelegate;
        public delegate void NotificationEventHandler(object sender, NotificationReceivedEventArgs e);
        public string? Message { get; set; }

        public int IdTypeNotification { get; set; }

        public void OnNotificationReceived()
        {
            NotificationConfirmed?.Invoke(this, EventArgs.Empty);
        }

        public void OnNotificationReceivedWithArgs(NotificationReceivedEventArgs args)
        {
            NotificationConfirmedWithArgs?.Invoke(this, args);
        }

        public void OnNotificationReceivedWithDelegate(NotificationReceivedEventArgs args)
        {
            NotificationConfirmedDelegate?.Invoke(this, args);
        }
    }

    public class NotificationReceivedEventArgs : EventArgs
    {
        public DateTime TimeNotificationReceived { get; set; }
        public string? Message { get; set; }
    }
}
