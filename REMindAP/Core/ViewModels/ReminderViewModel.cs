using REMindAP.Core.Domain;
using REMindAP.Core.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace REMindAP.Core.ViewModels
{
    public class ReminderViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string ShortDescription { get; set; }

        [Required]
        [Date]
        public string Date { get; set; }

        [Required]
        [Time]
        public string Time { get; set; }
        public bool IsRepeatable { get; set; }

        [Required]
        [Display(Name ="Reminder type")]
        public int ReminderTypeId { get; set; } = 1;
        public IEnumerable<ReminderType> ReminderTypes { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ReminderViewModel()
        {
            Notifications = new List<Notification>();
            ReminderTypes = new List<ReminderType>();
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format($"{Date} {Time}"));
        }
    }
}
