using System.ComponentModel.DataAnnotations;

namespace ClincSystem.DAL.Entities
{
    public class AppointmentSlot
    {
        [Key]
        public int SlotId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
        public bool IsBooked { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public Appointment Appointment { get; set; } // Navigation back from one-to-one
    }

}
