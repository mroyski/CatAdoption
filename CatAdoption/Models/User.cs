using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatAdoption.Models
{
    public class User
    {
        public string UserId { get; set; }
        public virtual IEnumerable<Cat> Cats { get; set; }
    }
}
