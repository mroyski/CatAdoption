using System.Collections.Generic;
using System.Linq;
using CatAdoption.Data;
using CatAdoption.Models;

namespace CatAdoption.Repositories
{
    public class CatRepository : ICatRepository
    {
        CatDbContext _db;

        public CatRepository(CatDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Cat> GetAll()
        {
            return _db.Cats.ToList();
        }

        public Cat GetById(int id)
        {
            return _db.Cats.Single(Cat => Cat.CatId == id);
        }

        public void Delete(Cat cat)
        {
            _db.Cats.Remove(cat);
            _db.SaveChanges();
        }
    }
}
