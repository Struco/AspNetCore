using Microsoft.AspNetCore.Mvc;
using Scratch.Services;
using Scratch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scratch.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService mailService;

        public AppController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            

            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //send it
                mailService.SendMessage("mindaugas@kubilius.lt", model.Subject, model.Message);
                ViewBag.UserMessage = "Mail sent";
                ModelState.Clear();
            }
            else
            {
                //error
            }
            
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";

            return View();
        }

    }
}
