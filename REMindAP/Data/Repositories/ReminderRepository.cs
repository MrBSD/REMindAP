using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using REMindAP.Core.Domain;
using REMindAP.Core.Interfaces;

namespace REMindAP.Data.Repositories
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly ApplicationDbContext _context;

        public ReminderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddReminder(Reminder reminder)
        {
            _context.Add(reminder);
        }

        public async Task<IEnumerable<Reminder>> GetFutureReminders(string userId)
        {
            return  await _context.Reminders
                .Where(r=>r.UserId==userId && r.EventDate>DateTime.Now && !r.IsCanceled)
                .Include(r=>r.ReminderTags)
                .OrderBy(r=>r.EventDate)
                .ToListAsync();
        }

        public async Task<Reminder> GetReminder(int id, string userId)
        {
            return  await _context.Reminders
                .Where(r => r.Id == id && r.UserId==userId)
                .Include(r=>r.Notifications)
                .SingleOrDefaultAsync();
        }

        public void DeleteReminder(Reminder reminder)
        {
            _context.Reminders.Remove(reminder);
        }

        public async Task<IEnumerable<Reminder>> GetCanceledReminders(string userId)
        {
            return await _context.Reminders
                .Where(r => r.UserId == userId && r.IsCanceled)
                .OrderBy(r=>r.EventDate)
                .ToListAsync();
        }
    }
}
