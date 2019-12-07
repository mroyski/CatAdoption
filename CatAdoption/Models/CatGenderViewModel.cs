using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatAdoption.Models
{
    public class CatGenderViewModel
    {
        public List<Cat> Cats { get; set; }
        public SelectList Genders { get; set; }
        public string CatGender { get; set; }
        public string Gender { get; set; }
    }
}
