using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClincSystem.DAL.Entities
{
    public class Doctor
    {
        [Key, ForeignKey("User")]
        public string DoctorId { get; set; }
        public string Bio { get; set; }
        public string Phone { get; set; }
        public int SpecializationId { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        public Specialization Specialization { get; set; }
        public ICollection<AppointmentSlot> AppointmentSlots { get; set; }
    }

}
