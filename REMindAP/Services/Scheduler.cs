using Hangfire;
using Microsoft.EntityFrameworkCore;
using REMindAP.Core.Interfaces;
using REMindAP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMindAP.Services
{
    public class Scheduler : IScheduler
    {
        private readonly INotificationService notificationService;

        public Scheduler(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public void Start ()
        {
            RecurringJob.AddOrUpdate(() => notificationService.Notify(), Cron.Minutely);
        }

    }
}
