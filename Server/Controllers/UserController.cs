using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Model;
using Server.Model.Dtos;
using Server.Repository.IRepository;

namespace Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            bool isUserUnique = _userRepo.IsUserUnique(user.Username);
            if (isUserUnique)
            {
                return BadRequest(new { message = "User Alredy exists" });
            }

            var newUser = _userRepo.Register(user.Username, user.Password);

            if (newUser == null)
            {
                return BadRequest(new { message = "Error while registering new user" });
            }

            UserDto obj = new UserDto()
            {
                Id = newUser.Id,
                Username = newUser.Username
            };
            return Ok(obj);
        }
         
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            var obj = _userRepo.Authenticate(user.Username,user.Password);

            return Ok(obj);
        }

        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var allUsers = _userRepo.GetAll();
            
            List<UserDto> users = new List<UserDto>();
            foreach(var user in allUsers)
            {
                UserDto userDto = new UserDto()
                {
                    Id = user.Id,
                    Username = user.Username,
                };
                users.Add(userDto);
            }
            return Ok(users);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return BadRequest(new { message = "ID doesnt exists" });
            }
            var deletedUser = _userRepo.Delete(id);
            
            /* We dont want to expose token and password so we've created Dto (Data transfer object)
             * which contains the fields which we want to expose
             */

            UserDto userDto = new UserDto()
            {
                Id = deletedUser.Id,
                Username = deletedUser.Username
            };
            return Ok(userDto);
        }
    }
}
