using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public DateTime CreationTime { get; set; }
        public string Path { get; set; }
        public User Author { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
