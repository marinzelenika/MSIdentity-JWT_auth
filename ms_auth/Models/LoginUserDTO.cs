using System.ComponentModel.DataAnnotations;

namespace ms_auth.Models
{
    public class LoginUserDTO
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; }
        [StringLength(15, ErrorMessage = "Your password is limited to {1} to {2} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
