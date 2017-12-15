using REMindAP.Core.Domain;
using REMindAP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMindAP.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmailSender emailSender;
        private readonly BrowserNotificationService browserService;

        public NotificationService(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            this.unitOfWork = unitOfWork;
            this.emailSender = emailSender;
            browserService = new BrowserNotificationService();
        }

        public async Task Notify()
        {
            var currentNotifications = await GetCurrentNotifications();
            foreach (var notification in currentNotifications)
            {
                await SendNotification(notification);
            }
            await unitOfWork.CompleteAsync();
        }

        private async Task SendNotification(Notification notification)
        {
            if (!notification.IsSent)
            {
                notification.Send();
                await SendEmail(notification);
                SendToSlack(notification);
                await SendToBrowser(notification);
            }
        }

        private async Task SendToBrowser(Notification notification)
        {
            await browserService.Send(notification);
        }

        private void SendToSlack(Notification notification)
        {
            string urlWithToken = "https://hooks.slack.com/services/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";
            SlackService client = new SlackService(urlWithToken);

            client.PostMessage(username: "REMindAP", 
                text:$"*{notification.Reminder.Title}* {notification.NotificationDateTime.ToString("dd.MM.yyyy HH:mm")}" +
                $"\n{notification.Reminder.ShortDescription}",
                channel: "#remindap");
        }

        private async Task SendEmail(Notification notification)
        {
            var email = notification.Reminder.User.Email;
            var subject = $"{notification.Reminder.Title} {notification.NotificationDateTime.ToString("dd.MM.yyyy HH:mm")}";
            var message = $"{notification.Reminder.Title} " +
                $"\n{notification.Reminder.ShortDescription}" +
                $"\n{notification.NotificationDateTime.ToString("dd.MM.yyyy HH:mm")}";

            await emailSender.SendEmailAsync(email, subject, message);
        }

        private async Task<IEnumerable<Notification>> GetCurrentNotifications()
        {
           return await unitOfWork.Notifications.GetNotificationsForSending();
        }

    }
}
