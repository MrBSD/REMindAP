using System.Collections.Generic;
using System.Threading.Tasks;
using REMindAP.Core.Domain;

namespace REMindAP.Core.Interfaces
{
    public interface INotificationsRepository
    {
        Task<IEnumerable<Notification>> GetNotificationsForSending();
        Task<IEnumerable<Notification>> GetNewNotifications(string userId);
    }
}