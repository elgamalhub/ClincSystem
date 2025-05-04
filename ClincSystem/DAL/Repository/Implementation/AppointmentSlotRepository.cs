using ClincSystem.DAL.DB;
using ClincSystem.DAL.Entities;
using ClincSystem.DAL.Repository.Interfaces;

namespace ClincSystem.DAL.Repository.Implementation
{
    public class AppointmentSlotRepository : BaseRepository<AppointmentSlot>, IAppointmentSlotRepository
    {
        public AppointmentSlotRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
