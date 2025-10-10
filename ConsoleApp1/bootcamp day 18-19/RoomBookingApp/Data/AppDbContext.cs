using Microsoft.EntityFrameworkCore;
using RoomBookingApp.Models;

namespace RoomBookingApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}