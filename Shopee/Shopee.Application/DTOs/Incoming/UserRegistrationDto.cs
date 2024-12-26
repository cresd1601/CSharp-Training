using System.ComponentModel.DataAnnotations;

namespace Shopee.Application.DTOs.Incoming
{
    public class UserRegistrationDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}