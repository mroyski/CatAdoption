using CatAdoption.Models;
using System.Collections.Generic;

namespace CatAdoption.Repositories
{
    public interface ICatRepository
    {
        IEnumerable<Cat> GetAll();
        Cat GetById(int id);
        void Delete(Cat cat);
        void AddCat(Cat cat);
    }
}
