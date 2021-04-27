using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AppLogin.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedule.Api.Dto;
using Schedule.Api.Sevices;
using Schedule.Data;
using Schedule.Domain;
using Schedule.Domain.User;

namespace Schedule.Api.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UserController : ControllerBase
    {
        public UserController(ScheduleContext scheduleContext)
        {
            _scheduleContext = scheduleContext;
        }

        private readonly ScheduleContext _scheduleContext;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var user = _scheduleContext.User.ToList();
            return Ok(user);
        }


        /// <summary>
        /// Method to validate the user's login
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> LogIn([FromBody] UserLoginDto userLoginDto)
        {

            var user = _scheduleContext.User.FirstOrDefault(a => a.Login == userLoginDto.Login);

            if (user == null) return Unauthorized("User not found. ");
            if (user.Password != userLoginDto.Password) return Unauthorized("Password does not match. ");

            var token = TokenService.GenerateToken(user);

            ReturnLoginDto returnLoginDto = new ReturnLoginDto()
            {
                Id = user.Id,
                Name = user.Name,
                Login = user.Login,
                Token = token
            };
            return Ok(returnLoginDto);
        }


        /// <summary>
        /// Method that updates a user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserDto userDto)
        {
            User user = _scheduleContext.User.FirstOrDefault(a => a.Id == id);

            if (user == null) return NotFound();
            user.UpdateUser(userDto.Name, userDto.Email, userDto.Login, userDto.Password, userDto.BirthDate, userDto.Sex);
            _scheduleContext.Update(user);
            await _scheduleContext.SaveChangesAsync();
            return Ok();
        }


        /// <summary>
        /// Method that deletes a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            User user = _scheduleContext.User.FirstOrDefault(u => u.Id == id);

            if (user == null) 
                return NotFound();

            _scheduleContext.Remove(user);
            await _scheduleContext.SaveChangesAsync();
            return Ok();
        }


        /// <summary>
        /// Method to register a user
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto userDto)
        {
            User user = new User(userDto.Name,
                userDto.Email,
                userDto.Login,
                userDto.Password,
                userDto.BirthDate,
                userDto.Sex);
            _scheduleContext.Add(user);
            await _scheduleContext.SaveChangesAsync();
            return Ok(user);
        }
    }
}
