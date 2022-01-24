using System.ComponentModel.DataAnnotations;

namespace ms_auth.Models
{
    public class UserDTO : LoginUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

    }
}
