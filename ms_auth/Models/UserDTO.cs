using System.ComponentModel.DataAnnotations;

namespace ms_auth.Models
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAdress { get; set; }
        [StringLength(15, ErrorMessage = "Your password is limited to {1} to {2} characters", MinimumLength = 6)]
        public string Password { get; set; }

    }
}
