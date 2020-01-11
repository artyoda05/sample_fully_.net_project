using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.DTO
{
    class RoleDTO
    {
        public string Name { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}
