
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using SimplificaITR.BackEnd.Controllers;
using SimplificaITR.BackEnd.Data;
using SimplificaITR.BackEnd.Data.Dtos.User;
using SimplificaITR.BackEnd.Models;
using SimplificaITR.BackEnd.Repository;
using System.Net;

namespace SimplificaITR.BackEnd.Tests.Controller
{
    public class UserControllerTests
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        public UserControllerTests()
        {
            _userRepository = A.Fake<IUserRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void RegisterUser_Returns_CreatedAtAction()
        {
            // Arrange
            var userDto = A.Fake<RegisterUserDto>();
            var user = A.Fake<User>();
            A.CallTo(() => _mapper.Map<User>(userDto)).Returns(user);
            var controller = new UserController(_userRepository, _mapper);

            // Act
            var result = controller.RegisterUser(userDto);

            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.CreatedAtActionResult>(result);
        }

        [Fact]
        public void GetAllUsers_Returns_IEnumerableUsers()
        {
            // Arrange
            var users = A.Fake<IEnumerable<User>>();
            A.CallTo(() => _userRepository.GetAll()).Returns(users);
            var controller = new UserController(_userRepository, _mapper);

            // Act
            var result = controller.GetAllUsers();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<User>>(result);
        }

        [Fact]
        public void GetUserById_Returns_Ok()
        {
            // Arrange
            int id = 1;
            var user = A.Fake<User>();
            A.CallTo(() => _userRepository.GetById(id)).Returns(user);
            var controller = new UserController(_userRepository, _mapper);

            // Act
            var result = controller.GetUserById(id);

            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);
        }

        [Fact]
        public void GetUserById_Returns_NotFound()
        {
            // Arrange
            int id = 1;
            var user = A.Fake<User>();
            A.CallTo(() => _userRepository.GetById(id)).Returns(null);
            var controller = new UserController(_userRepository, _mapper);

            // Act
            var result = controller.GetUserById(id);

            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result);
        }


        [Fact]
        public void LoginUser_Returns_Ok()
        {
            // Arrange
            var user = A.Fake<User>();
            A.CallTo(() => _userRepository.GetByEmail(user.Email)).Returns(user);
            var controller = new UserController(_userRepository, _mapper);

            // Act
            var result = controller.LoginUser(new LoginUserDto { Email = user.Email, Password = user.Password });

            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);
        }

        [Fact]
        public void LoginUser_Returns_NotFound()
        {
            // Arrange
            var user = A.Fake<User>();
            A.CallTo(() => _userRepository.GetByEmail(user.Email)).Returns(null);
            var controller = new UserController(_userRepository, _mapper);

            // Act
            var result = controller.LoginUser(new LoginUserDto { Email = user.Email, Password = user.Password });

            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundObjectResult>(result);
        }

        [Fact]
        public void LoginUser_Returns_BadRequest()
        {
            // Arrange
            var user = A.Fake<User>();
            A.CallTo(() => _userRepository.GetByEmail(user.Email)).Returns(new() { Password = "not_a_password" });
            var controller = new UserController(_userRepository, _mapper);

            // Act
            var result = controller.LoginUser(new LoginUserDto { Email = user.Email, Password = user.Password });

            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>(result);
        }
    }
}