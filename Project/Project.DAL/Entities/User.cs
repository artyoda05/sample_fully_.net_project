using System.ComponentModel.DataAnnotations;


namespace Project.DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public bool IsAuthor { get; set; }
        public bool IsAdmin { get; set; }
    }
}
