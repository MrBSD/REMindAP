using Microsoft.EntityFrameworkCore;
using REMindAP.Core.Domain;
using REMindAP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMindAP.Data.Repositories
{
    public class ReminderTypesRepository : IReminderTypesRepository
    {
        private readonly ApplicationDbContext context;

        public ReminderTypesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ReminderType>> GetReminderTypes()
        {
            return await context.ReminderTypes.ToListAsync();
        }
    }
}
