namespace Super.Digital.Infrastructure.Notifiers
{
    public class Notification
    {
        public Notification(string message)
        {
            this.Message = message;
        }
        public string Message { get; }
    }
}
