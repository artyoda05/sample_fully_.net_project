using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Project.BLL.DTO;
using Project.BLL.Interfaces;
using Project.BLL.Services;
using Project.WebAPI.Models;

namespace Project.WebAPI.Controllers
{
    [RoutePrefix("/api/user")]
    [Authorize(Roles = "admin")]
    public class UserController : ApiController
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService userService)
        {
            _userService = userService;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserVM, UserDTO>();
                cfg.CreateMap<UserDTO, UserVM>();
            });
            _mapper = new Mapper(config);
        }

        // GET api/<controller>
        public IEnumerable<UserVM> Get()
        {
            return _mapper.Map<IEnumerable<UserVM>>(_userService.GetAll());
        }

        // PUT api/<controller>
        public void Put([FromBody] UserVM value)
        {
            _userService.Update(_mapper.Map<UserDTO>(value));
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            _userService.Remove(_userService.GetUserById(id));
        }
    }
}