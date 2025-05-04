using ClincSystem.DAL.DB;
using ClincSystem.DAL.Entities;
using ClincSystem.DAL.Repository.Interfaces;

namespace ClincSystem.DAL.Repository.Implementation
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
