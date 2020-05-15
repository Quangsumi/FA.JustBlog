using FA.JustBlog.Core.Models;
using System.Data.Entity;

namespace FA.JustBlog.Core.Data
{
    public class JustBlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public JustBlogContext() : base("JustBlog") { }

        static JustBlogContext()
        {
            //Database.SetInitializer<JustBlogContext>(new MigrateDatabaseToLatestVersion<JustBlogContext, Migrations.Configuration>());
            //Database.SetInitializer<JustBlogContext>(new JustBlogInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Posts)
                .Map(pt =>
                {
                    pt.ToTable("PostTag");
                    pt.MapLeftKey("PostId");
                    pt.MapRightKey("TagId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
