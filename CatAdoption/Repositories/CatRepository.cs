using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatAdoption.Data;
using CatAdoption.Models;

namespace CatAdoption.Repositories
{
    public class CatRepository : ICatRepository
    {
        ApplicationDbContext _db;

        public CatRepository(ApplicationDbContext db)
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
    }
}
