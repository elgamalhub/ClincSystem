using ClincSystem.DAL.DB;
using ClincSystem.DAL.Entities;
using ClincSystem.DAL.Repository.Interfaces;

namespace ClincSystem.DAL.Repository.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
