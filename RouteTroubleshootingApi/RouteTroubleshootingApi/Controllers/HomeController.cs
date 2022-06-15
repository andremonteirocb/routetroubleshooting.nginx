using Microsoft.AspNetCore.Mvc;
using RouteTroubleshootingApi.Models;
using System.Diagnostics;

namespace RouteTroubleshootingApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["APP_NAME"] = _configuration.GetValue<string>("APP_NAME");
            ViewData["MACHINE_NAME"] = Environment.MachineName;
            ViewData["REQUEST_HOST"] = Request.Host.Value;
            ViewData["REQUEST_PATH"] = Request.Path;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}