using Anray.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Anray.Controllers
{
    public class HomeController : Controller
    {
        private readonly AnrayContext _anrayContext;

        public HomeController(AnrayContext anrayContext)
        {
            _anrayContext = anrayContext;
        }
       
        public IActionResult Index()
        {
            List<Team> teams = _anrayContext.Teams.ToList();
            return View(teams);
        }

    }
}