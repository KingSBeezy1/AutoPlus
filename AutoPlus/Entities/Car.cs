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
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Brand { get; set; }
        [Required]
        [StringLength(30)]
        public string Model { get; set; }
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
        public string HorsePowers { get; set; }
        [Required]
        public string ThumbnailImagePath { get; set; }
        
    }
}
