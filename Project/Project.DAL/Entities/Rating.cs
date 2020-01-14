using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project.DAL.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int MaterialId { get; set; }
        [ForeignKey("MaterialId")]
        public Material Material { get; set; }
        public string AssignerId { get; set; }
        [ForeignKey("AssignerId")]
        public virtual UserProfile Assigner { get; set; }
    }
}
