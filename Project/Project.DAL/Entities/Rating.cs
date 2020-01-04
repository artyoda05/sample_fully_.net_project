using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public Material Material { get; set; }
        public User Assigner { get; set; }
    }
}
