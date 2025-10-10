using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoomBookingApp.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public int Capacity { get; set; }

        public List<Booking>? Bookings { get; set; }
    }
}