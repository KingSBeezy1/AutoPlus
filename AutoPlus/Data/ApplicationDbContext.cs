using AutoPlus.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoPlus.Data
{
    public class User : IdentityUser
    {
        
        private DateTime DateTime = DateTime.Now;
        [DataType(DataType.Date)]
       [StringLength(40)]
       [Required(ErrorMessage = "This field is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is Required")]
       [StringLength(40)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(30)]
        public string City { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(10)]
        public string TelephoneNumber { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(10)]
        public int EGN { get; set; }
        public DateTime CreationDate
        {
            get { return DateTime; }
            set { DateTime = value; }
        }
        
        [ForeignKey("UserId")]
        public virtual ICollection<User> UsersId { get; set; }
        
    }
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Car> Category { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Userss { get; set; }
        public DbSet<AutoPlus.Entities.Brands> Brands { get; set; }
        public DbSet<AutoPlus.Entities.ModelBrands> ModelBrands { get; set; }
        
    }
}
