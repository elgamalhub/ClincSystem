using ClincSystem.DAL.Repository.Interfaces;

namespace ClincSystem.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository Appointments {  get; }
        IAppointmentSlotRepository AppointmentSlots { get; }
        IDoctorRepository Doctors { get; }
        IPatientRepository Patients { get; }
        ISpecializationRepository Specializations {  get; }
        IUserRepository Users { get; }
        Task SaveAsync();
    }
}
