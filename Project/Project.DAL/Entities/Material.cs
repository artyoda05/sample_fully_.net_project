using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project.DAL.Entities
{
    public class Material
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public DateTime AddedAt { get; set; }
        public string Path { get; set; }
        
        public string AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual UserProfile Author { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
