using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REMindAP.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using REMindAP.Models;

namespace REMindAP.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Reminders")]
    [Authorize]
    public class RemindersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public RemindersController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Cancel (int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var reminder = await _unitOfWork.Reminders.GetReminder(id, userId);

            if (reminder == null || reminder.IsCanceled)
                return NotFound();

            if (reminder.UserId != userId)
                return Unauthorized();

            reminder.Cancel();
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var reminder = await _unitOfWork.Reminders.GetReminder(id, userId);

            if (reminder == null)
                return NotFound();

            if (reminder.UserId != userId)
                return Unauthorized();

            _unitOfWork.Reminders.DeleteReminder(reminder);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }

    }
}