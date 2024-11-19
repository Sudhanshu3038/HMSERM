using HMSERM.Data;
using HMSERM.Dtos;
using HMSERM.Interface.Repository;
using HMSERM.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMSERM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _dbContext;

        public UserController(IUserRepository userRepository, IUserService userService, ApplicationDbContext dbContext)
        {
            _userRepository = userRepository;
            _userService = userService;
            _dbContext = dbContext;
        }

        // GET: api/<UserController>
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("GetUserById/{userId}")]

        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _dbContext.Users
                       .Where(x => x.UserId == userId)
                       .ToListAsync();

            if (user == null)
            {
                return NotFound("User Not Exist");
            }

            return new OkObjectResult(user);
        }

        // POST api/<UserController>/5
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddAsync([FromBody] UserDto dto)
        {
            var result = await _userService.AddUser(dto);
            return Ok(result);
        }
        // PUT api/<UserController>
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateAsync(int id, UserDto dto)
        {
            var result = await _userService.UpdateUser(id, dto);
            return Ok(result);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
