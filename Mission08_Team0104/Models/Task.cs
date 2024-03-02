using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0104.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required]
        public string TaskItem {  get; set; }

        public string? DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool? IsCompleted { get; set; }
    }
}
