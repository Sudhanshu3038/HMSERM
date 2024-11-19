using HMSERM.Data;
using HMSERM.Interface.Repository;
using HMSERM.Model;

namespace HMSERM.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task Delete(User entity)
        {
            _dbContext.Set<User>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
