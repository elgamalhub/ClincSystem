namespace ClincSystem.DAL.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int SlotId { get; set; }
        public AppointmentSlot Slot { get; set; }

        public string Status { get; set; }  // "Pending", "Confirmed", "Canceled"
        public string Notes { get; set; }
    }
}
