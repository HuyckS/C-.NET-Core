using Microsoft.EntityFrameworkCore;

namespace LoginAndReg.Models
{
    public class LoginUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}