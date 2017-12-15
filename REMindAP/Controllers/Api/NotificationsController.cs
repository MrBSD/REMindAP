using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REMindAP.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using REMindAP.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using REMindAP.Core.Domain;
using REMindAP.Core.Dto;

namespace REMindAP.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Notifications")]
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public NotificationsController(IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpGet("GetNewNotifications")]
        public async Task<IActionResult> GetNewNotifications()
        {

            var notifications = await unitOfWork.Notifications
                .GetNewNotifications(userManager.GetUserId(HttpContext.User));

            var notificationsDto = mapper.Map<IEnumerable<Notification>, IEnumerable<NotificationDto>>(notifications);
            return Ok(notificationsDto);
        }

        [HttpPost("read")]
        public async Task<IActionResult> ReadNotifications()
        {
            var notifications = await unitOfWork.Notifications
                .GetNewNotifications(userManager.GetUserId(HttpContext.User));
                        
            foreach (var notification in notifications)
            {
                notification.SetRead();
            }

            await unitOfWork.CompleteAsync();
            return Ok();
        }
    }
}