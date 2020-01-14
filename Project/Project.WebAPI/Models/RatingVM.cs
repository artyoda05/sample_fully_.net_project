using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.WebAPI.Models
{
    public class RatingVM
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int MaterialId { get; set; }
        [Required]
        public string Assigner { get; set; }
    }
}