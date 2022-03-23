using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPlus.Entities
{
    public class ModelBrands
    {
        public int Id { get; set; }
        public int IdBrand { get; set; }
        public string Model { get; set; }
        [NotMapped]
        public virtual ICollection<SelectListItem> ModelTypes { get; set; }
       // public ICollection<Brands> BrandsModels { get; set; }

    }
}
