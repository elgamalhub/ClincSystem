using ClincSystem.DAL.DB;
using ClincSystem.DAL.Repository.Interfaces;

namespace ClincSystem.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IAppointmentRepository Appointments { get; }
        public IAppointmentSlotRepository AppointmentSlots { get; }
        public IDoctorRepository Doctors { get; }
        public IPatientRepository Patients { get; }
        public ISpecializationRepository Specializations { get; }
        public IUserRepository Users { get; }
        public UnitOfWork(ApplicationDbContext context,
                          IAppointmentRepository appointmentRepository,
                          IAppointmentSlotRepository appointmentSlotRepository,
                          IDoctorRepository doctorRepository,
                          IPatientRepository patientRepository,
                          ISpecializationRepository specializationRepository,
                          IUserRepository userRepository
                          )
        {
            _context = context;
            Appointments = appointmentRepository;
            AppointmentSlots = appointmentSlotRepository;
            Doctors = doctorRepository;
            Patients = patientRepository;
            Specializations = specializationRepository;
            Users = userRepository;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
            return;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
