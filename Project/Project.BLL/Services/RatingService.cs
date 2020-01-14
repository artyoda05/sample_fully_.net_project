using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Project.BLL.DTO;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.BLL.Services
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public RatingService(IUnitOfWork db)
        {
            _db = db;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MaterialDTO, Material>();
                cfg.CreateMap<Material, MaterialDTO>();
                cfg.CreateMap<RatingDTO, Rating>();
                cfg.CreateMap<Rating, RatingDTO>();
                cfg.CreateMap<UserProfile, UserDTO>();
                cfg.CreateMap<UserDTO, UserProfile>();

                cfg.CreateMap<ApplicationUser, UserDTO>();
                cfg.CreateMap<UserDTO, ApplicationUser>();
            });
            _mapper = new Mapper(config);
        }
        public void Create(RatingDTO item)
        {
            _db.Ratings.Create(_mapper.Map<Rating>(item));
        }
    }
}
