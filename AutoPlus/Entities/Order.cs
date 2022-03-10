using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPlus.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        [Required]
        public DateTime TimeDate { get; set; }
        
    }
}
