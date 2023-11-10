using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace GraduationProject.Models
{
    public class Context : IdentityDbContext<User>
    {

        public Context()
        {
        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer("Data Source=.;Initial Catalog=GraduationProject77;Integrated Security=True");//dbms , server name , db, autha-windows
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryForRestaurant> CategoryForRestaurant { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<SpecializationsForDoctors> specializationsForDoctors { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    // the one-to-many relationship between Admin and category
        //    //modelBuilder.Entity<Category>()
        //    // .HasOne(a => a.Admin)
        //    // .WithMany(c => c.Categories)
        //    // .HasForeignKey(a => a.AdminId)
        //    // .OnDelete(DeleteBehavior.Restrict);



        //}
    }
}
