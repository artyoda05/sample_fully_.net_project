using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.DTO
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int MaterialId { get; set; }
        public string AssignerId { get; set; }
        public MaterialDTO Material { get; set; }
        public UserDTO Assigner { get; set; }
    }
}
