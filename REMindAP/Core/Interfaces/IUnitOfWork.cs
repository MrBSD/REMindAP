using System.Threading.Tasks;

namespace REMindAP.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IReminderRepository Reminders { get; }
        INotificationsRepository Notifications { get; }
        IReminderTypesRepository ReminderTypes { get; }
        Task CompleteAsync();
    }
}
