using System.ComponentModel.DataAnnotations;

namespace Todo.Dtos
{
    public class ItemCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
