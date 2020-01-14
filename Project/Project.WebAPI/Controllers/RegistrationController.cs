using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Project.BLL.DTO;
using Project.BLL.Interfaces;
using Project.WebAPI.Models;

namespace Project.WebAPI.Controllers
{
    [RoutePrefix("api/auth")]
    public class RegistrationController : ApiController
    {
        private IUserService _userService;

        public RegistrationController(IUserService userService) => _userService = userService;

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> Register([FromBody] RegisterModel userToBeCreated)
        {

            if (userToBeCreated == null) 
                return BadRequest($"{nameof(userToBeCreated)} must be passed");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = new UserDTO()
            {
                UserName = userToBeCreated.UserName,
                Password = userToBeCreated.Password,
                Bio = userToBeCreated.Bio,
                Name = userToBeCreated.Name,
                Email = userToBeCreated.Email,
                Role = "client"
            };
            await _userService.Create(user);
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("initialize")]
        public async Task Initialize()
        {
            await _userService.SetInitialData(new UserDTO
            {
                UserName = "admin1",
                Password = "123456",
                Email = "email1@mail.com",
                Role = "admin",
                Name = "admin"
            }, new List<string>() {"admin", "client"});
        }
    }
}