using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using REMindAP.Core.Domain;
using REMindAP.Core.Interfaces;
using REMindAP.Core.ViewModels;
using REMindAP.Data;
using REMindAP.Data.Repositories;
using REMindAP.Models;
using REMindAP.Services;
using AutoMapper;

namespace REMindAP.Controllers
{
    [Authorize]   
    public class RemindersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public RemindersController(IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var reminders = await _unitOfWork.Reminders.GetFutureReminders(userId);
            return View(reminders);
        }

        [HttpGet]
        public async Task<IActionResult> Canceled ()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var reminders = await _unitOfWork.Reminders.GetCanceledReminders(userId);
            return View("Canceled",reminders);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new ReminderViewModel
            {
                Date = DateTime.Now.ToString("dd.MM.yyyy"),
                Time = DateTime.Now.AddHours(+1).ToString("HH:mm"),
                ReminderTypes = await _unitOfWork.ReminderTypes.GetReminderTypes()
            };

            return View("ReminderForm", viewModel);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var reminder = await _unitOfWork.Reminders.GetReminder(id, userId);
            if (reminder == null)
                return NotFound("Not found");

            _unitOfWork.Reminders.DeleteReminder(reminder);
            await _unitOfWork.CompleteAsync();

            return RedirectToAction("Index", "Reminders");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var reminder = await _unitOfWork.Reminders.GetReminder(id, userId);

            if (reminder == null)
                return NotFound();

            var viewModel = _mapper.Map<Reminder, ReminderViewModel>(reminder);
            viewModel.Date = reminder.EventDate.ToString("d.MM.yyyy");
            viewModel.Time = reminder.EventDate.ToString("HH:mm");
            viewModel.ReminderTypes = await _unitOfWork.ReminderTypes.GetReminderTypes();

            return View("ReminderForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ReminderViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("ReminderForm", viewModel);

            var userId = _userManager.GetUserId(HttpContext.User);
            var eventDate = viewModel.GetDateTime();
            if (viewModel.Id == 0)
            {
                var reminder = _mapper.Map<ReminderViewModel, Reminder>(viewModel);
                reminder.UserId = userId;
                reminder.EventDate = eventDate;
                reminder.AddNotification(eventDate, isDefault: true);
                _unitOfWork.Reminders.AddReminder(reminder);
            }
            else
            {
                var reminderInDb = await _unitOfWork.Reminders.GetReminder(viewModel.Id, userId);
                _mapper.Map<ReminderViewModel, Reminder>(viewModel, reminderInDb);
                reminderInDb.EventDate = eventDate;
                
                var defaultNotification = reminderInDb.Notifications
                    .Where(n=>n.IsDefault==true && !n.IsSent)
                    .Single();

                defaultNotification.NotificationDateTime = eventDate;
            }

            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Index", "Reminders");
        }
    }
}