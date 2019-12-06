using CatAdoption.Data;
using CatAdoption.Models;
using System.Collections.Generic;
using System.Linq;

namespace CatAdoption.Repositories
{
    public class AdoptRepository : IAdoptRepository
    {
        AdoptDbContext _db;

        public AdoptRepository(AdoptDbContext db)
        {
            _db = db;
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
        }

        public IEnumerable<Adoption> GetAll()
        {
            return _db.Adoptions.ToList();
        }
    }
}
