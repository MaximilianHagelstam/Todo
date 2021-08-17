using System.ComponentModel.DataAnnotations;

namespace Todo.Dtos
{
    public class BookCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }
    }
}
