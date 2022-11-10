using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class updateEmplyeeViewModel
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
    }
}
