using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBookingApp.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Room")]
        public int RoomId { get; set; }

        public Room? Room { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public string BookedBy { get; set; } = "";
    }
}