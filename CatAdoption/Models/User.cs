using System.Collections.Generic;

namespace CatAdoption.Models
{
    public class User
    {
        public string UserId { get; set; }
        public virtual IEnumerable<Cat> Cats { get; set; }
    }
}
