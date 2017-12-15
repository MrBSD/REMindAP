using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REMindAP.Models;
using REMindAP.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using REMindAP.Services;

namespace REMindAP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManage;

        public HomeController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManage)
        {
            this.unitOfWork = unitOfWork;
            this.userManage = userManage;
          
        }


        public IActionResult Index()
        {

            return RedirectToAction("Index", "Reminders");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
