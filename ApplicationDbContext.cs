using JWT_TokenBased.Helper.Utils;
using JWT_TokenBased.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT_TokenBased
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base (options) { }


        public ApplicationDbContext()
        {

        }

        public virtual DbSet<UserModel> User { get; set; }
        public virtual DbSet<StoryModel> Story { get; set; }
        public virtual DbSet<LoginDetailModel> LoginDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(GlobalAttributes.mysqlConfiguration.connectionString, ServerVersion.AutoDetect(GlobalAttributes.mysqlConfiguration.connectionString));
            }
     
        }



    }
}

