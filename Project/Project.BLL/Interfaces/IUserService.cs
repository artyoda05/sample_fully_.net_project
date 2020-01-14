using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.BLL.DTO;

namespace Project.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task Create(UserDTO userDto);
        Task<UserDTO> Authenticate(string userName, string password);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
        void Remove(UserDTO userDTO);
        void Update(UserDTO userDTO);
        UserDTO GetUserById(string id);
        IEnumerable<UserDTO> GetAll();
    }
}