using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using REMindAP.Core.Domain;
using System.Collections.ObjectModel;

namespace REMindAP.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Reminder> Reminders { get; set; }

        public ApplicationUser()
        {
            Reminders = new Collection<Reminder>();
        }
    }
}
