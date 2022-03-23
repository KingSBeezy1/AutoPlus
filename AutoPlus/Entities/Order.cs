using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPlus.Entities
{
    public class Order
    {
        private DateTime _releaseDate = DateTime.MinValue;
        public int Id { get; set; }

        public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Order")]
        public DateTime TimeDate
        {
            get
            {
                return (_releaseDate == DateTime.MinValue) ? DateTime.Now : _releaseDate;
               // return _releaseDate = DateTime.Now;
            }
            set
            {
                _releaseDate = value;
            }
        }
       
    }
}
