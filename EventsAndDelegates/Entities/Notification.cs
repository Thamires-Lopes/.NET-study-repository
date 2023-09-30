namespace EventsAndDelegates.Entities
{
    public class Notification
    {
        public event EventHandler? NotificationConfirmed;
        public event NotificationEventHandler? NotificationConfirmedDelegate;
        public event EventHandler<NotificationReceivedEventArgs>? NotificationConfirmedWithArgs;
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
    }
}
