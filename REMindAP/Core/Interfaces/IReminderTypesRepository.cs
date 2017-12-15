using System.Collections.Generic;
using System.Threading.Tasks;
using REMindAP.Core.Domain;

namespace REMindAP.Core.Interfaces
{
    public interface IReminderTypesRepository
    {
        Task<IEnumerable<ReminderType>> GetReminderTypes();
    }
}