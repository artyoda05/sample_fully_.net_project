using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Project.BLL.DTO;
using Project.BLL.Interfaces;
using Project.WebAPI.Models;

namespace Project.WebAPI.Controllers
{
    [RoutePrefix("/api/material")]
    [Authorize]
    public class MaterialController : ApiController
    {
        private IMaterialService _materialService;
        private IMapper _mapper;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MaterialVM, MaterialDTO>();
                cfg.CreateMap<MaterialDTO, MaterialVM>();
                cfg.CreateMap<UserVM, UserDTO>();
                cfg.CreateMap<UserDTO, UserVM>();
                cfg.CreateMap<RatingVM, RatingDTO>();
                cfg.CreateMap<RatingDTO, RatingVM>();
            });
            _mapper = new Mapper(config);
        }

        // GET api/<controller>
        public IEnumerable<MaterialVM> Get()
        {
            return _mapper.Map<IEnumerable<MaterialVM>>(_materialService.GetAll());
        }

        // GET api/<controller>/5
        public MaterialVM Get(int id)
        {
            return _mapper.Map<MaterialVM>(_materialService.GetById(id));
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] MaterialVM value)
        {
            _materialService.Create(_mapper.Map<MaterialDTO>(value), value.AuthorId);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]MaterialVM value)
        {
            value.Id = id;
            _materialService.Update(_mapper.Map<MaterialDTO>(value));
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _materialService.Remove(_materialService.GetById(id));
        }
    }
}