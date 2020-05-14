using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRHub_API.Contracts;
using HRHub_API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRHub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILoggerService _logger;
        //private readonly IConfiguration _config;

        public UserController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILoggerService logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger; 
        }
        /// <summary>
        /// User login 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
       
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] UserDTO userDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                var userName = userDTO.Username;
                var password = userDTO.Password;
                _logger.LogInfo($" Login Attempt from user {userName} ");
                var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(userName);
                    return Ok(user);
                }
                return Unauthorized(userDTO);
            }
            catch (Exception e)
            {

                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
          

            
        }
        private object GetControllerActionNames()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }

        private ObjectResult InternalError(string message)
        {
            _logger.LogError(message);
            return StatusCode(500, "somehting went wrong, please contact with Administrator");
        }
    }
}