using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjWerkdigital.Models
{
    [Table("Users")]
    public class UserModel
    {

        //public UserModel()
        //{
        //    Tasks = new Collection<Task>();
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string? Email { get; set; }

        [Required]
        [StringLength(80)]
        public string? Password { get; set; }
        public ICollection<TaskModel> Tasks { get; } = new List<TaskModel>();
    }
}
