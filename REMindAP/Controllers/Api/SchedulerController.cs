using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REMindAP.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using REMindAP.Services;

namespace REMindAP.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Scheduler")]
    [Authorize]
    public class SchedulerController : Controller
    {
        private readonly IScheduler scheduler;
        private readonly INotificationService notificationService;

        public SchedulerController(IScheduler scheduler, INotificationService notificationService)
        {
            this.scheduler = scheduler;
            this.notificationService = notificationService;
        }

        [HttpGet("Start")]
        public IActionResult Start()
        {
            scheduler.Start();
            return Ok();
        }

        [HttpGet("Notify")]
        public IActionResult Notify()
        {
            notificationService.Notify();
            return Ok();
        }

    }
}