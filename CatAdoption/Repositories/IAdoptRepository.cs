using CatAdoption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatAdoption.Repositories
{
    public interface IAdoptRepository
    {
        void Adopt(Cat cat, string userId);
        IEnumerable<Adoption> GetAll();
    }
}
