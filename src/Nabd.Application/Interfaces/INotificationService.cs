using Nabd.Core.Enums.Notifications;

namespace Nabd.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(
            Guid userId,
            NotificationType type,
            string title,
            string message,
            Guid? relatedEntityId = null,
            string? relatedEntityType = null,
            NotificationPriority priority = NotificationPriority.Normal);

        Task SendRealtimeNotificationAsync(
            Guid userId,
            string title,
            string message,
            object? data = null);
    }
}
