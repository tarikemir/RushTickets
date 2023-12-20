using System.ComponentModel.DataAnnotations;

namespace RushTickets.MVC.ViewModels
{
    public class AuthLoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}
