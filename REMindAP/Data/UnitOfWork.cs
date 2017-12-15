using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REMindAP.Core.Interfaces;
using REMindAP.Data.Repositories;

namespace REMindAP.Data
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IReminderRepository Reminders { get; private set; }

        public INotificationsRepository Notifications { get; private set; }

        public IReminderTypesRepository ReminderTypes { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Reminders = new ReminderRepository(context);
            Notifications = new NotificationsRepository(context);
            ReminderTypes = new ReminderTypesRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
