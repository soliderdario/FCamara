using System.Collections.Generic;

namespace Super.Digital.Infrastructure.Notifiers
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void SetNotification(Notification notification);
    }
}
