using System.Collections.Generic;
using System.Threading.Tasks;
using REMindAP.Core.Domain;

namespace REMindAP.Core.Interfaces
{
    public interface IReminderRepository
    {
        void AddReminder(Reminder reminder);
        Task<IEnumerable<Reminder>> GetFutureReminders(string UserId);
        Task<Reminder> GetReminder(int id, string userId);
        void DeleteReminder(Reminder reminder);
        Task<IEnumerable<Reminder>> GetCanceledReminders(string userId);
    }
}