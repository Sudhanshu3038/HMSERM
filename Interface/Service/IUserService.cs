using HMSERM.Dtos;
using HMSERM.Model;

namespace HMSERM.Interface.Service
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<User> AddUser(UserDto dto);

        Task<User> UpdateUser(int id, UserDto dto);

        Task<bool> DeleteUser(int id);
    }
}
