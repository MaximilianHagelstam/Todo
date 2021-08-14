using System.ComponentModel.DataAnnotations;

namespace Todo.Dtos
{
    public class ItemUpdateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
