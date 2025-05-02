namespace ClincSystem.DAL.Entities
{
    public class Specialization
    {
        public int SpecializationId { get; set; }
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }

}
