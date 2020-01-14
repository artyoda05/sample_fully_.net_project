using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.WebAPI.Models
{
    public class MaterialVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Info { get; set; }
        public DateTime AddedAt { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public string AuthorId { get; set; }
        public double Rating { get; set; }
    }
}