using CatAdoption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatAdoption.Repositories
{
    public interface ICatRepository
    {
        IEnumerable<Cat> GetAll();
        Cat GetById(int id);
    }
}
