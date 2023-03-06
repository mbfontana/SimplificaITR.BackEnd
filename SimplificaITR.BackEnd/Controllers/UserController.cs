using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SimplificaITR.BackEnd.Data.Dtos.User;
using SimplificaITR.BackEnd.Models;
using SimplificaITR.BackEnd.Repository;
using SimplificaITR.BackEnd.Services;

namespace SimplificaITR.BackEnd.Controllers
{

    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private ITokenService _tokenManager;

        public UserController(IUserRepository userRepository, IMapper mapper, ITokenService tokenManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenManager = tokenManager;
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            User user = _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            GetUserByIdDto userDto = _mapper.Map<GetUserByIdDto>(user);

            return Ok(userDto);
        }

        [HttpPost("email")]
        public IActionResult GetUserByEmail([FromBody] GetUserByEmailDto userDto)
        {
            User user = _userRepository.GetByEmail(userDto.Email);

            if (user == null)
            {
                return Ok();
            }

            return Conflict();
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] RegisterUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);

            _userRepository.Add(user);
            _userRepository.Save();

            return CreatedAtAction(nameof(GetUserById), new { Id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto userDto)
        {
            User user = _userRepository.GetById(id);
            if (user != null)
            {
                _mapper.Map(userDto, user);
                _userRepository.Save();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            User user = _userRepository.GetById(id);
            if (user != null)
            {
                _userRepository.Delete(user);
                _userRepository.Save();
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] LoginUserDto userDto)
        {
            User user = _userRepository.GetByEmail(userDto.Email);

            if (user == null)
            {
                return NotFound("E-mail not registered");
            }
            else if (user.Password != userDto.Password)
            {
                return BadRequest("The password is incorrect");
            }

            var token = _tokenManager.Authenticate(user.Email);

            if (token == null)
            {
                return Unauthorized("User not authorized");
            }

            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Headers", "Origin, Content-Type, X-Auth-Token");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");

            return Ok(new { user.Name, user.Email, token });
        }

    }
}
