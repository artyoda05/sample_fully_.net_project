using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.DTO
{
    class RatingDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public MaterialDTO Material { get; set; }
        public UserDTO Assigner { get; set; }
    }
}
