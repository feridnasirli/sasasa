using Anray.Helpers;
using Anray.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anray.Areas.manage.Controllers
{
    [Area("manage")]
    public class TeamController : Controller
    {
        private readonly AnrayContext _anrayContext;
        private readonly IWebHostEnvironment _web;

        public TeamController(AnrayContext anrayContext,IWebHostEnvironment web)
        {
            _anrayContext = anrayContext;
            _web = web;
        }
        public IActionResult Index()
        {
            List<Team> teams = _anrayContext.Teams.ToList();
            return View(teams);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if(team.ImageFile.ContentType!="image/png" && team.ImageFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "Only .jpeg and .png");
                return View();
            }
            team.Image = FileManeger.saveFile(_web.WebRootPath, "uploads/teams", team.ImageFile);
            _anrayContext.Teams.Add(team);
            _anrayContext.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Team team = _anrayContext.Teams.Find(id);
            return View(team);
        }
        [HttpPost]
        public IActionResult Update(Team team)
        {
            Team exteam=_anrayContext.Teams.FirstOrDefault(x=>x.Id == team.Id);
            if(team == null)
            {
                return NotFound();
            }
            if(team.ImageFile !=null)
            {
                if (team.ImageFile.ContentType != "image/png" && team.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Only .jpeg and .png");
                    return View();
                }
                string name = FileManeger.saveFile(_web.WebRootPath, "uploads/teams", team.ImageFile);
                FileManeger.DeleteFile(_web.WebRootPath, "uploads/teams", exteam.Image);
                exteam.Image = name;
            }
            exteam.Title = team.Title;
            exteam.FullName= team.FullName;
            exteam.RedirectUrl= team.RedirectUrl;
            
            _anrayContext.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Team team=_anrayContext.Teams.FirstOrDefault(x=>x.Id==id);
            if(team == null)
            {
                return NotFound();
            }
            if(team.Image != null)
            {
                FileManeger.DeleteFile(_web.WebRootPath, "uploads/teams", team.Image);
            }
            _anrayContext.Remove(team);
            _anrayContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
