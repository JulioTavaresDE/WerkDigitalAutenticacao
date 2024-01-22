using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;


namespace PrjWerkdigital.Models
{
    [Table("Tasks")]
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [StringLength(80)]
        public string? Name { get; set; }
        public DateTime? Date_Begin { get; set; }       
        public DateTime? Date_End { get; set; }
        public int UserId { get; set; }
        public UserModel? User { get; set; }
    }
}
