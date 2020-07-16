using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hangfire.Demo.Models;

namespace Hangfire.Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ////Fire-and-forget
         //   BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget Job Executed"));

            ////Delayed job
         //  BackgroundJob.Schedule(() => Console.WriteLine("Delayed job executed"), TimeSpan.FromMinutes(1));
          
           RecurringJob.AddOrUpdate(() => Console.WriteLine("Minutely Job executed"), Cron.Minutely);

            //var id = BackgroundJob.Enqueue(() => Console.WriteLine("Hello, "));
            // BackgroundJob.ContinueWith(id, () => Console.WriteLine("world!"));

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
