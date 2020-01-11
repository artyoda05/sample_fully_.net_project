using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.DTO
{
    class MaterialDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public DateTime AddedAt { get; set; }
        public string Path { get; set; }
        public UserDTO Author { get; set; }
        public ICollection<RatingDTO> Ratings { get; set; }
    }
}
