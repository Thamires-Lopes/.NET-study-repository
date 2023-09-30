namespace EventsAndDelegates.Entities
{
    public class Notification
    {
        public event EventHandler NotificationConfirmed;
        public string? Message { get; set; }

        public int IdTypeEmail { get; set; }

        public void OnNotificationReceived()
        {
            NotificationConfirmed?.Invoke(this, EventArgs.Empty);
        }
    }
}
