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
    [Authorize]
    [RoutePrefix("/api/rating")]
    public class RatingController : ApiController
    {
        private IRatingService _ratingService;
        private IMaterialService _materialService;
        private IMapper _mapper;

        public RatingController(IRatingService ratingService, IMaterialService materialService)
        {
            _ratingService = ratingService;
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

        // GET api/<controller>/5
        public double Get(int materialId)
        {
            return _materialService.GetRating(materialId);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] RatingVM value)
        {
            _ratingService.Create(_mapper.Map<RatingDTO>(value));
        }
    }
}