using HMSERM.Data;
using HMSERM.Dtos;
using HMSERM.Enums;
using HMSERM.Helper;
using HMSERM.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;



namespace HMSERM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpPost("SignUp")]
        public async Task<IActionResult> CreateUser(UserDto req)
        {
            try
            {
                if (req.Role != null)
                {
                    foreach (var role in req.Role)
                    {
                        if (!Enum.IsDefined(typeof(RolesEnum), role))
                        {
                            return BadRequest($"Invalid role specified: {role}");
                        }
                    }
                }

                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == req.Email);

                if (existingUser != null)
                {

                    foreach (var role in req.Role)
                    {
                        if (!existingUser.Role.Contains(role))
                        {

                            existingUser.Role.Add(role);
                        }
                    }

                    _context.Users.Update(existingUser);
                    await _context.SaveChangesAsync();

                    return Ok(existingUser);
                }

                User user = new User 
                {
                    Email = req.Email,
                    PasswordHash = CryptoHelper.HashPass(req.Password, out var salt),
                    PasswordSalt = salt,
                    Role = new List<RolesEnum>(req.Role),
                    ClinicId = req.ClinicId
                };

                await _context.Users.AddAsync(user);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Ok(user);
                }
                else
                {
                    throw new Exception("Failed to create user due to a system exception.");
                }
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> Login([FromBody] LoginDto Request)
        {
            try
            {
                var userDetail = await _context.Users.FirstOrDefaultAsync(u => u.Email == Request.Email);

                if (userDetail == null || !CryptoHelper.isValidPass(Request.Password, userDetail.PasswordHash, userDetail.PasswordSalt))
                {
                    throw new Exception("Invalid Login");
                }

                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, userDetail.UserId.ToString()),
                    new Claim(ClaimTypes.Email, userDetail.Email),

                };
                foreach (var role in userDetail.Role)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                }
                var accessToken = JwtHelper.GenerateAccessToken(
                    _configuration.GetValue<string>("JWT:IssuerSigningKey"),
                    _configuration.GetValue<string>("JWT:ValidIssuer"),
                    _configuration.GetValue<string>("JWT:ValidAudience"),
                    claims);

                var refreshToken = JwtHelper.GenerateAccessToken(
                    _configuration.GetValue<string>("JWT:IssuerSigningKey"),
                    _configuration.GetValue<string>("JWT:ValidIssuer"),
                    _configuration.GetValue<string>("JWT:ValidAudience"),
                    claims);

                var token = new Token
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    AccessTokenExpiry = DateTime.Now.AddDays(1),
                    RefreshTokenExpiry = DateTime.Now.AddDays(3),
                    UserId = userDetail.UserId
                };

                _context.Tokens.Add(token);
                await _context.SaveChangesAsync();

                var response = new AuthResponseDto
                {
                    Token = new TokenAuthDto
                    {
                        AccessToken = accessToken,
                        RefreshToken = refreshToken,
                    },
                    User = new UserAuthDto
                    {
                        UserId = userDetail.UserId,
                        Role = userDetail.Role,
                        Email=userDetail.Email
                    }
                };
                return Ok(new { token = response.Token, user = response.User });
            }

            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }


        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenAuthDto request)
        {
            var token = await _context.Tokens
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.RefreshToken == request.RefreshToken);

            if (token == null || token.RefreshTokenExpiry < DateTime.Now)
            {
                return BadRequest("Invalid or expired refresh token");
            }


            List<Claim> claims = new List<Claim>()
            {
             new Claim(ClaimTypes.NameIdentifier, token.User.UserId.ToString()),
             new Claim(ClaimTypes.Email, token.User.Email),

             };
            foreach (var role in token.User.Role)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var newAccessToken = JwtHelper.GenerateAccessToken(
                _configuration.GetValue<string>("JWT:IssuerSigningKey"),
                _configuration.GetValue<string>("JWT:ValidIssuer"),
                _configuration.GetValue<string>("JWT:ValidAudience"),
                claims
            );


            token.AccessToken = newAccessToken;
            token.AccessTokenExpiry = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();

            return Ok(new { AccessToken = newAccessToken, RefreshToken = token.RefreshToken });
        }
        [Authorize]
        [HttpGet("GetById/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            try
            {
                var user = await _context.Users
                    .Where(u => u.UserId == userId)
                    .Select(u => new
                    {
                        u.Email,
                        u.Role,
                        u.ClinicId,
                        u.UserId,
                    })
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    return NotFound($"User with ID {userId} not found.");
                }

                return new OkObjectResult(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [Authorize]
        [HttpPut("UpdateUser/{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, UserDto req)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
                if (user == null)
                {
                    return NotFound($"User with ID {userId} not found.");
                }

                user.Email = req.Email;
                user.Role = req.Role;

                _context.Users.Update(user);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Ok("User updated successfully.");
                }
                else
                {
                    throw new Exception("Failed to update the user.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
