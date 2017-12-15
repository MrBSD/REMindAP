using Microsoft.EntityFrameworkCore;
using REMindAP.Core.Domain;
using REMindAP.Core.Dto;
using REMindAP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMindAP.Data.Repositories
{
    public class NotificationsRepository : INotificationsRepository
    {
        private readonly ApplicationDbContext context;

        public NotificationsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Notification>> GetNotificationsForSending()
        {
            var result = await context.Notifications
                .Where(n => n.NotificationDateTime <= GetCurrentTime() && !n.IsSent)
                .Include(n => n.Reminder)
                    .ThenInclude(r => r.User)
                .ToListAsync();

            return result;
        }

       
        public async Task<IEnumerable<Notification>> GetNewNotifications(string userId)
        {
            var result = await context.Notifications
                .Include(n => n.Reminder)
                .Where(n=>n.Reminder.UserId==userId && !n.IsRead && n.IsSent)
                .ToListAsync();
                
            return result;
        }

        private static DateTime GetCurrentTime()
        {
            var currentTimeString = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            DateTime currentTime = DateTime.Parse(currentTimeString);
            return currentTime;
        }
    }
}
