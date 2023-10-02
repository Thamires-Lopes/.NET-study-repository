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

        // Here is the invocation method. Note that we pass an empty event args because this event doesn't have nothing to be passed
        public void OnNotificationReceived()
        {
            NotificationConfirmed?.Invoke(this, EventArgs.Empty);
        }

        // Here are the invocation methods. Note that we pass the arguments
        public void OnNotificationReceivedWithArgs(NotificationReceivedEventArgs args)
        {
            NotificationConfirmedWithArgs?.Invoke(this, args);
        }

        public void OnNotificationReceivedWithDelegate(NotificationReceivedEventArgs args)
        {
            NotificationConfirmedDelegate?.Invoke(this, args);
        }
    }

    // This is the class that we use to pass arguments to the event
    public class NotificationReceivedEventArgs : EventArgs
    {
        public DateTime TimeNotificationReceived { get; set; }
        public string? Message { get; set; }
    }
}
