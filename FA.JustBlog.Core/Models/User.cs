using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FA.JustBlog.Core.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        [StringLength(1024, ErrorMessage = "The {0} must be less than {1} characters")]
        public string Avatar { get; set; }

        [Display(Name = "Introduction")]
        [StringLength(1024, ErrorMessage = "The {0} must be less than {1} characters")]
        public string Intro { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "The {0} format is not correct")]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "The {0} format is not correct")]
        public DateTime? ModifiedDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}