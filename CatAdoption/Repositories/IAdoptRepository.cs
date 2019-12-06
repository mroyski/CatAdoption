using CatAdoption.Models;
using System.Collections.Generic;

namespace CatAdoption.Repositories
{
    public interface IAdoptRepository
    {
        void Adopt(Cat cat, string userId);
        IEnumerable<Adoption> GetAll();
    }
}
