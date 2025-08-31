using Microsoft.EntityFrameworkCore;
using resturangApi.Models;

namespace resturangApi.Data
{
    public class ResturangApiDbContext : DbContext
    {
        public ResturangApiDbContext(DbContextOptions<ResturangApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Menu>().HasData(
                new Menu
                {
                    MenuId = 1,
                    Name = "Pizza Margherita",
                    Price = 120,
                    Description = "Classic pizza with tomato sauce, mozzarella cheese, and fresh basil.",
                    IsPopular = true,
                    ImageUrl = "https://example.com/images/pizza-margherita.jpg"
                },
                new Menu
                {
                    MenuId = 2,
                    Name = "Spaghetti Carbonara",
                    Price = 150,
                    Description = "Traditional Italian pasta dish with eggs, cheese, pancetta, and pepper.",
                    IsPopular = true,
                    ImageUrl = "https://example.com/images/spaghetti-carbonara.jpg"
                },
                new Menu
                {
                    MenuId = 3,
                    Name = "Caesar Salad",
                    Price = 100,
                    Description = "Crisp romaine lettuce with Caesar dressing, croutons, and parmesan cheese.",
                    IsPopular = false,
                    ImageUrl = "https://example.com/images/caesar-salad.jpg"
                });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = new Guid(),
                    Name = "admin",
                    PasswordHash = "9A0DEEADB7A880BC314CA2F3C7FF1A25EDC4B1B62FAE7743FDFC95F514314ECD.976DFD14270865CD5E53DE94E856F97E",

                });

            modelBuilder.Entity<Table>().HasData(
                new Table
                {
                    TableId = 1,
                    TableNumber = 1,
                    Seats = 4,
                    
                },
                new Table
                {
                    TableId = 2,
                    TableNumber = 2,
                    Seats = 2,
                    
                },
                new Table
                {
                    TableId = 3,
                    TableNumber = 3,
                    Seats = 6,
                    
                });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
}
