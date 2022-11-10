using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class EmpTask
    {
        [Key]
        public int TskId { get; set; }
        public string? TskName { get; set; }

        //Navigation Properties
        [ForeignKey("Employee")]
        public int EmpId { get; set; }
        public Employee Employee { get; set; }

    }
}
