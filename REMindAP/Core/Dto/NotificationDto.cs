using System;

namespace REMindAP.Core.Dto
{
    public class NotificationDto
    {

        public ReminderDto Reminder { get; set; }
        public DateTime NotificationDateTime { get; set; }
        public bool IsSent { get; set; }
        public bool IsRead { get; set; }
        public bool IsDefault { get; set; }
    }
}