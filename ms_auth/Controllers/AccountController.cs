using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ms_auth.Data;
using ms_auth.Models;

namespace ms_auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<ApiUser> userManager, SignInManager<ApiUser> signInManager,
            ILogger<AccountController> logger, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration attempt for user {UserDTO.EmailAddress}" );
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                var result = await _userManager.CreateAsync(user);

                if (!result.Succeeded)
                {
                    return BadRequest("User registration attempt failed");
                }

                return Ok(200);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in the {nameof(Register)}");
                return StatusCode(500, $"Something went wrong in the {nameof(Register)}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO LoginUserDTO)
        {
            _logger.LogInformation($"Login attempt for user {UserDTO.EmailAddress}");
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var result =
                    await _signInManager.PasswordSignInAsync(LoginUserDTO.EmailAddress, LoginUserDTO.Password, false, false);

                if (!result.Succeeded)
                {
                    return Unauthorized(LoginUserDTO);
                }

                return Accepted();
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in the {nameof(Login)}");
                return StatusCode(500, $"Something went wrong in the {nameof(Login)}");
            }
        }
    }
}
