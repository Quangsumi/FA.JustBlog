using FA.JustBlog.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace FA.JustBlog.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext() : base("JustBlogContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}