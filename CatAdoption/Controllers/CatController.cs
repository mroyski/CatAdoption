using CatAdoption.Models;
using CatAdoption.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatAdoption.Controllers
{
    public class CatController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        ICatRepository _catRepo;

        public CatController(ICatRepository catRepo, UserManager<IdentityUser> userManager)
        {
            _catRepo = catRepo;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var model = _catRepo.GetAll();
            return View(model);
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var model = _catRepo.GetById(id);
            return View(model);
        }

        [HttpGet("cat/adopt")]
        [Authorize]
        public async Task<IActionResult> AdoptAsync(int id)
        {
            var model = _catRepo.GetById(id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public string AdoptSuccess(int id)
        {
            var model = _catRepo.GetById(id);
            return $"Successfully adopted {model.Name}";
        }
    }
}
