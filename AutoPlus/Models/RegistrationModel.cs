using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPlus.Models
{
    public class RegistrationModel
    {
        private DateTime _registerDate = DateTime.MinValue;
        [Required]
        [EmailAddress]
        [Display(Name ="User Name")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [StringLength(100,MinimumLength =2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        
        public int EGN { get; set; }
       

        public DateTime RegisterTime
        {
            get
            {
                return (_registerDate == DateTime.MinValue) ? DateTime.Now : _registerDate;
                // return _releaseDate = DateTime.Now;
            }
            set
            {
                _registerDate = value;
            }
        }
        [Required]
        [RegularExpression(@"(\+)?(359|0)8[789]\d{1}(|-| )\d{3}(|-| )\d{3}")]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        public string RegistrationInValid { get; set; }
        public bool AcceptUserAgreement { get; set; }
    }
}
