using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Activity> activities { get; set; }
        public DbSet<SubActivity> sub_activities { get; set; }
        public DbSet<CategoryLkp> category_lkp { get; set; }
        public DbSet<StatusLkp> status_lkp { get; set; }
    }
}