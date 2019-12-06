using CatAdoption.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CatAdoption.Controllers
{
    public class CatController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        ICatRepository _catRepo;
        IAdoptRepository _adoptRepo;

        public CatController(ICatRepository catRepo, IAdoptRepository adoptRepo, UserManager<IdentityUser> userManager)
        {
            _catRepo = catRepo;
            _userManager = userManager;
            _adoptRepo = adoptRepo;

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
    }
}
