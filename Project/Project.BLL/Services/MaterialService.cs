using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Project.BLL.DTO;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.BLL.Services {
    
    public class MaterialService : IMaterialService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public MaterialService(IUnitOfWork db)
        {
            _db = db;
            _userService = new UserService(db);
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
        public void Create(MaterialDTO item, string author)
        {
            item.AddedAt = DateTime.Now;
            var material = _mapper.Map<Material>(item);
            _db.Materials.Create(material);
            _db.Save();
        }

        public MaterialDTO GetById(int id)
        {
            var material = _db.Materials.Read(id);
            var res = _mapper.Map<MaterialDTO>(material);
            res.Rating = GetRating(material);
            return res;
        }

        public IEnumerable<MaterialDTO> GetAll()
        {
            var materials = _db.Materials.ReadAll();
            var res = _mapper.Map<IEnumerable<MaterialDTO>>(materials);
            for (var i = 0; i < res.Count(); i++)
                res.ElementAt(i).Rating = GetRating(materials.ElementAt(i));
            return res;
        }

        public void Remove(MaterialDTO item)
        {
            var material = _db.Materials.Read(item.Id);
            _db.Materials.Delete(material);
            _db.Save();
        }

        public void Update(MaterialDTO item)
        {
            var material = _db.Materials.Read(item.Id);
            material = _mapper.Map(item, material);
            _db.Materials.Delete(material);
            _db.Save();
        }

        public double GetRating(int materialId)
        {
            return GetRating(_db.Materials.Read(materialId));
        }

        private double GetRating(Material material)
        {
            var sum = material.Ratings.Sum(el => el.Number);
            var count = material.Ratings.Count;
            return 1.0 * sum / 
                   (count != 0 ? count : 1);
        }
    }
}
