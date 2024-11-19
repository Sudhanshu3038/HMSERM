using HMSERM.Dtos;
using HMSERM.Helper;
using HMSERM.Interface.Repository;
using HMSERM.Interface.Service;
using HMSERM.Model;

namespace HMSERM.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUser(UserDto dto)
        {
            User user = new User();
            user.Email = dto.Email;
            user.Role = dto.Role;
            user.PasswordHash = CryptoHelper.HashPass(dto.Password, out var salt);
            user.PasswordSalt = salt;
            user.ClinicId = dto.ClinicId;

            return await _userRepository.AddAsync(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            await _userRepository.Delete(user);
            return true;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return users.ToList();
        }

        public async Task<User> UpdateUser(int id, UserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            user.Email = dto.Email;
            user.Role = dto.Role;
            user.ClinicId = dto.ClinicId;

            return await _userRepository.UpdateAsync(user);
        }
    }
}