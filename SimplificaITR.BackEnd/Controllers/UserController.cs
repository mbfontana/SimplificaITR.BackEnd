using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplificaITR.BackEnd.Data;
using SimplificaITR.BackEnd.Data.Dtos;
using SimplificaITR.BackEnd.Models;
using SimplificaITR.BackEnd.Repository;

namespace SimplificaITR.BackEnd.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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

            return Ok(user);
        }

    }
}
