using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }    
                                                
        //Navigation Properties

        public List<EmpTask> EmpTasks { get; set; }
    }
}
