using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HMSERM.Model
{
    public class Token
    {
        public int TokenId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime AccessTokenExpiry { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
