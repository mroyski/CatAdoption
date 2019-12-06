using CatAdoption.Data;
using CatAdoption.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatAdoption.Repositories
{
    public class AdoptRepository : IAdoptRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        AdoptDbContext _db;
        CatDbContext _catDb;

        public AdoptRepository(AdoptDbContext db, CatDbContext catDb, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _catDb = catDb;
            _userManager = userManager;
        }

        public void Adopt(Cat cat, string userId)
        {
            var record = new Adoption()
            {
                UserId = userId,
                CatId = cat.CatId,
                Name = cat.Name,
                Gender = cat.Gender,
                Age = cat.Age,
                Bio = cat.Bio

            };
            _db.Adoptions.Add(record);
            _db.SaveChanges();
            _catDb.Cats.Remove(cat);
            _catDb.SaveChanges();
        }

        public IEnumerable<Adoption> GetAll()
        {
            return _db.Adoptions.ToList();
        }
    }
}
