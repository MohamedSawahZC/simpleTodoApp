using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class TodoItem
    {
        [Required]
        [Range(1,100)]
        public long Id { get; set; }

        [Required]
        [StringLength(maximumLength:9,MinimumLength =2)]
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
