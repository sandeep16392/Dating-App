using System.ComponentModel.DataAnnotations;

namespace DatingApp.Model.DataModels
{
    public class UserDm
    {
        [Required]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "Username should have 7 to 20 characters.")]
        public string Username { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Password Length should be between 7 to 15 characters.")]
        public string Password { get; set; }
    }
}
