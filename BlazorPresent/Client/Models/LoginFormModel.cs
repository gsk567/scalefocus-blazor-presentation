using System.ComponentModel.DataAnnotations;

namespace BlazorPresent.Client.Models
{
    public class LoginFormModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
