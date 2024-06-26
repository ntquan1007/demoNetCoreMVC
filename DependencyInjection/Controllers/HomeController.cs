using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static DependencyInjection.Services.Dependency;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMyDependency _dependencyService;

 
        public HomeController(ILogger<HomeController> logger, IMyDependency myDependency)
        {
            _logger = logger;
            _dependencyService = myDependency;
        }

        public IActionResult Index()
        {
            _dependencyService.WriteMessage("Hello DEPENDENCY INJECTION");
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
