using GameHUB.Models;
using GameHUB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameHUB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameServices _gameServices;

        public HomeController(IGameServices gameServices)
        {
            _gameServices = gameServices;
        }

        public IActionResult Index()
        {
            var games = _gameServices.GateAll();
            return View(games);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
