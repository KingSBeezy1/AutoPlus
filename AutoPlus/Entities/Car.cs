using AutoPlus.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPlus.Entities
{
    public class Car 
    {
       
        public int Id { get; set; }
        
        public int IdBrandModel { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int YearProduction { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Condition { get; set; }
        [Required]
        public string Injection { get; set; }
        [Required]
        public int HorsePowers { get; set; }
        [Required]
        [Display(Name = "Thumbnal Image Path")]
        public string ThumbnailImagePath { get; set; }

    }
}
