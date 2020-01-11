using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.DAL.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public Material Material { get; set; }
        public virtual UserProfile Assigner { get; set; }
    }
}
