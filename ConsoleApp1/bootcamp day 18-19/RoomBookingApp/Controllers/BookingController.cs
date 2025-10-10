using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoomBookingApp.Data;
using RoomBookingApp.Models;

namespace RoomBookingApp.Controllers
{
    public class BookingsController : Controller
    {
        private readonly AppDbContext _context;

        public BookingsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings
                .Include(b => b.Room)
                .ToListAsync();
            return View(bookings);
        }

        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                // Cek bentrok tanggal
                bool overlap = _context.Bookings.Any(b =>
                    b.RoomId == booking.RoomId &&
                    b.EndDate >= booking.StartDate &&
                    b.StartDate <= booking.EndDate);

                if (overlap)
                {
                    ModelState.AddModelError("", "Ruangan sudah dipesan di tanggal tersebut.");
                    ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", booking.RoomId);
                    return View(booking);
                }

                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", booking.RoomId);
            return View(booking);
        }
    }
}
