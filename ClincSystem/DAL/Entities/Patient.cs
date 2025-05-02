using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClincSystem.DAL.Entities
{
    public class Patient
    {
        [Key, ForeignKey("User")]
        public string PatientId { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Phone { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }

}
