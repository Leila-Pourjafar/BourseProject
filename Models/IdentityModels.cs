using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bourse.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Bourse.Migrations.Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>()
        //        .HasMany(e => e.SubCategories)
        //        .WithOptional(e => e.Category)
        //        .HasForeignKey(e => e.CategoryId);
        //}
        public System.Data.Entity.DbSet<Bourse.Models.Symbol> Symbols { get; set; }
        public System.Data.Entity.DbSet<Bourse.Models.Category> Categories { get; set; }
        public DbSet<Bourse.Models.SubCategories> SubCategories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PotentialCustomer> PotentialCustomers { get; set; }

        public System.Data.Entity.DbSet<Bourse.Models.Product> Products { get; set; }
        public DbSet<JoinedHologram> joinedHolograms { get; set; }
        public DbSet<HologramOwner> HologramOwners { get; set; }
    }
}