using HMSERM.Model;

namespace HMSERM.Interface.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task Delete(User entity);
    }
}
