using System.ComponentModel.DataAnnotations;

namespace CatAdoption.Models
{
    public class Adoption
    {
        [Key]
        public int AdoptionId { get; set; }
        public string UserId { get; set; }
        public int CatId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }
    }
}
