using ClincSystem.DAL.DB;
using ClincSystem.DAL.Entities;
using ClincSystem.DAL.Repository.Interfaces;

namespace ClincSystem.DAL.Repository.Implementation
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
