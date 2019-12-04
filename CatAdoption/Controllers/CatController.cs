using CatAdoption.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatAdoption.Controllers
{
    public class CatController : Controller
    {
        ICatRepository catRepo;
        public CatController(ICatRepository catRepo)
        {
            this.catRepo = catRepo;
        }
        public IActionResult Index()
        {
            var model = catRepo.GetAll();
            return View(model);
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var model = catRepo.GetById(id);
            return View(model);
        }
    }
}
