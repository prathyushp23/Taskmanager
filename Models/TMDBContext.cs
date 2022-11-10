using Microsoft.EntityFrameworkCore;
using System.Data;

namespace TaskManager.Models
{
    public class TMDBContext : DbContext
    {
        public TMDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employee {get; set;}
        public DbSet<EmpTask> EmpTask {get; set;}


    }
}
