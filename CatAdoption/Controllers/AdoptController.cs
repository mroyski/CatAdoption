using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CatAdoption.Controllers
{
    public class AdoptController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdoptController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: Adopt
        public async Task<string> IndexAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return user.ToString();
        }

        // GET: Adopt/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}