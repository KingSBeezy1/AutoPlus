using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPlus.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FamilyName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string City { get; set; }
        [Required]
        [StringLength(10)]
        public int EGN { get; set; }
        public DateTime RegisterDate { get; set; }
        [Required]
        [StringLength(10)]
        public int PhoneNumber { get; set; }
    }
}
