using System;
using System.Collections.Generic;
using REMindAP.Models;
using System.Collections.ObjectModel;

namespace REMindAP.Core.Domain
{
    public class Reminder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string ShortDescription { get; set; }
        public DateTime EventDate { get; set; }
        public bool IsCanceled { get; private set; }
        public bool IsRepeatable { get; set; }

        public int ReminderTypeId { get; set; }
        public ReminderType ReminderType { get; set; }
        public ICollection<ReminderTag> ReminderTags { get; set; }
        public ICollection<Notification> Notifications { get;  set; }


        public Reminder()
        {
            ReminderTags = new List<ReminderTag>();
            Notifications = new List<Notification>();
        }

        public void SetNextDate()
        {
            switch (ReminderTypeId)
            {
                case 1:
                    break;
                case 2:
                    EventDate = EventDate.AddHours(+1);
                    AddNotification(EventDate, true);
                    break;
                case 3:
                    EventDate = EventDate.AddDays(+1);
                    AddNotification(EventDate, true);
                    break;
            }
        }

        public void Cancel ()
        {
            IsCanceled = true;
        }

        public void AddNotification(DateTime dateTime, bool isDefault)
        {
            var notification = new Notification(dateTime);
            notification.IsDefault = isDefault;
            Notifications.Add(notification);
        }
    }
}
