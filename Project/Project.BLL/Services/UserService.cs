using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Interfaces;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Project.BLL.DTO;
using Project.BLL.Interfaces;
using Project.DAL.Entities;

namespace Project.BLL.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        public IUnitOfWork Db { get; }

        public UserService(IUnitOfWork uow)
        {
            Db = uow;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserProfile, UserDTO>();
                cfg.CreateMap<UserDTO, UserProfile>();
                cfg.CreateMap<Material, MaterialDTO>();
                cfg.CreateMap<MaterialDTO, Material>();

                cfg.CreateMap<ApplicationUser, UserDTO>();
                cfg.CreateMap<UserDTO, ApplicationUser>();

                cfg.CreateMap<ApplicationRole, UserDTO>();
                cfg.CreateMap<UserDTO, ApplicationRole>();
            });
            _mapper = new Mapper(config);
        }

        public async Task Create(UserDTO userDto)
        {
            var user = await Db.Users.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser {Email = userDto.Email, UserName = userDto.UserName};
                var result = await Db.Users.CreateAsync(user, userDto.Password);
                if (result.Errors.Any())
                    throw new Exception(result.Errors.FirstOrDefault());
                await Db.Users.AddToRoleAsync(user.Id, userDto.Role);
                var profile = new UserProfile{Id = user.Id, Bio = userDto.Bio, Name = userDto.Name};
                Db.Profiles.Create(profile);
                await Db.SaveAsync();
            }
            else
            {
                throw new Exception("The user is already created!");
            }
        }

        public async Task<UserDTO> Authenticate(string userName, string password)
        {
            var userApp = await Db.Users.FindAsync(userName, password);
            return userApp is null
                ? null
                : CreateUserDTO(userApp, new UserProfile());
        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                
                var role = await Db.Roles.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Db.Roles.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Remove(UserDTO userDTO)
        {
            var appUser = Db.Users.FindById(userDTO.Id);
            appUser = _mapper.Map(userDTO, appUser);
            Db.Users.Delete(appUser);
            Db.Save();
        }

        public void Update(UserDTO userDTO)
        {
            var userProfile = Db.Profiles.Read(userDTO.Id);
            userProfile = _mapper.Map(userDTO, userProfile);
            Db.Profiles.Update(userProfile);

            var appUser = Db.Users.FindById(userDTO.Id);
            // for updating role
            var oldRoleId = appUser.Roles.SingleOrDefault().RoleId;
            var oldRoleName = Db.Roles.FindById(oldRoleId).Name;
            if (oldRoleName != userDTO.Role)
            {
                Db.Users.RemoveFromRole(userDTO.Id, oldRoleName);
                Db.Users.AddToRole(userDTO.Id, userDTO.Role);
            }
            appUser = _mapper.Map(userDTO, appUser);
            Db.Users.Update(appUser);
            Db.Save();
        }

        public UserDTO GetUserById(string id)
        {
            ApplicationUser appUser = Db.Users.FindById(id);
            UserProfile profile = Db.Profiles.Read(id);
            return CreateUserDTO(appUser, profile);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            List<ApplicationUser> appList = Db.Users.Users.ToList();
            List<UserProfile> userProfile = Db.Profiles.ReadAll().ToList();
            List<UserDTO> usersDTO = new List<UserDTO>();
            for (int i = 0; i < appList.Count(); i++)
            {
                usersDTO.Add(CreateUserDTO(appList.ElementAtOrDefault(i), userProfile.ElementAtOrDefault(i)));
            }
            return usersDTO;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (this._disposed) return;
            if (disposing)
            {
                Db.Dispose();
            }
            this._disposed = true;
        }

        private UserDTO CreateUserDTO(ApplicationUser appUser, UserProfile profile)
        {
            profile ??= new UserProfile();
            return new UserDTO()
            {
                Id = appUser.Id,
                Email = appUser.Email,
                Bio = profile.Bio,
                Name = profile.Name,
                Password = appUser.PasswordHash,
                Role = Db.Users.GetRoles(appUser.Id).FirstOrDefault(),
                UserName = appUser.UserName
            };
        }
    }
}
