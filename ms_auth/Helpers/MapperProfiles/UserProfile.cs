using AutoMapper;
using ms_auth.Data;
using ms_auth.Models;

namespace ms_auth.Helpers.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApiUser, UserDTO>();
        }
    }
}
