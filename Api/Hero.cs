using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Api
{
    public class Hero
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required] 
        public string LastName { get; set; }
        public string? Place { get; set; }
    }
}
