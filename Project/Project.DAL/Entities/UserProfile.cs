using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Entities
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
