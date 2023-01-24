using Anray.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Anray.Areas.manage.Controllers
{
    [Area("manage")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<ActionResult> CreateAdmin() 
        //{
        //    AppUser user = new AppUser
        //    {
        //        Fullname = "Ferid Nesirli",
        //        UserName = "SuperAdmin"
        //    };
        //    var result = await _userManager.CreateAsync(user,"Ferid2003");
        //    return Ok(result);
        //}
    }
}
