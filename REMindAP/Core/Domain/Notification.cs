using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMindAP.Core.Domain
{
    public class Notification
    {
        public int Id { get; set; }
        public int ReminderId { get; set; }
        public Reminder Reminder { get; set; }
        public DateTime NotificationDateTime { get; set; }
        public bool IsSent { get; set; }
        public bool IsRead { get; private set; }
        public bool IsDefault { get; set; }

        public Notification()
        {

        }

        public Notification(DateTime dateTime)
        {
            NotificationDateTime = dateTime;
        }

        public void SetRead()
        {
            IsRead = true;
        }

        public void Send()
        {
            IsSent = true;

            if (IsDefault)
                Reminder.SetNextDate();
        }
    }
}
