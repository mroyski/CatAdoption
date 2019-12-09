using CatAdoption.Data;
using CatAdoption.Models;
using CatAdoption.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CatAdoption.Controllers
{
    public class CatController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly CatDbContext _catContext;
        private readonly IWebHostEnvironment _hostingEnvironment;
        ICatRepository _catRepo;
        IAdoptRepository _adoptRepo;

        public CatController(ICatRepository catRepo, IAdoptRepository adoptRepo, UserManager<IdentityUser> userManager, CatDbContext catContext, IWebHostEnvironment hostingEnvironment)
        {
            _catRepo = catRepo;
            _userManager = userManager;
            _adoptRepo = adoptRepo;
            _catContext = catContext;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index(string catGender, int catAge)
        {
            IQueryable<string> genderQuery = from g in _catContext.Cats
                                             orderby g.Gender
                                             select g.Gender;

            var cats = from g in _catContext.Cats
                       select g;

            IQueryable<int> ageQuery = from a in _catContext.Cats
                                       orderby a.Age
                                       select a.Age;

            var ageCats = from a in _catContext.Cats
                          select a;

            if (catAge != 0 && (!string.IsNullOrEmpty(catGender)))
            {
                cats = cats.Where(x => x.Age == catAge && x.Gender == catGender);
            }
            else if (!string.IsNullOrEmpty(catGender))
            {
                cats = cats.Where(x => x.Gender == catGender);
            }
            else if (catAge != 0)
            {
                cats = cats.Where(x => x.Age == catAge);
            }

            var catFilterVM = new CatFilterViewModel
            {
                Genders = new SelectList(await genderQuery.Distinct().ToListAsync()),
                Ages = new SelectList(await ageQuery.Distinct().ToListAsync()),
                Cats = await cats.ToListAsync()
            };

            return View(catFilterVM);
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var model = _catRepo.GetById(id);
            return View(model);
        }

        [HttpGet("cat/adopt")]
        [Authorize]
        public IActionResult Adopt(int id)
        {
            var model = _catRepo.GetById(id);
            return View(model);
        }

        [HttpGet("cat/adopt/success/{id}")]
        [Authorize]
        public async Task<IActionResult> AdoptSuccessAsync(int id)
        {
            var cat = _catRepo.GetById(id);
            var userId = await _userManager.GetUserAsync(HttpContext.User);
            _adoptRepo.Adopt(cat, userId.ToString());
            return RedirectToAction("Index");
        }

        [HttpGet("cat/adoptedcats")]
        [Authorize]
        public IActionResult AdoptedCats()
        {
            var model = _adoptRepo.GetAll();
            return View(model);
        }

        [HttpGet("cat/mycats")]
        [Authorize]
        public async Task<IActionResult> MyCatsAsync()
        {
            var userId = await _userManager.GetUserAsync(HttpContext.User);
            var currentUser = userId.ToString();
            var usersCats = _adoptRepo.GetAll()
                   .Where(usersCats => usersCats.UserId == currentUser);
            return View(usersCats);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddCat(int id)
        {
            var addCatVM = new AddCatViewModel();
            return View(addCatVM);
        }        

        [HttpPost]
        [Authorize]
        public IActionResult AddCat(AddCatViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Image != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "imgs");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Cat newCat = new Cat
                {
                    Name = model.Name,
                    Age = model.Age,
                    Gender = model.Gender,
                    Bio = model.Bio,
                    ImagePath = uniqueFileName
                };
                _catRepo.AddCat(newCat);
                return RedirectToAction("Details", new { id = newCat.CatId });
            }
            return View();
        }
    }
}
