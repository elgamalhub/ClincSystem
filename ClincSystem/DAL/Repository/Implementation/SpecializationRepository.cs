using ClincSystem.DAL.DB;
using ClincSystem.DAL.Entities;
using ClincSystem.DAL.Repository.Interfaces;

namespace ClincSystem.DAL.Repository.Implementation
{
    public class SpecializationRepository : BaseRepository<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
