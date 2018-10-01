using System.Data.Entity;
using ConsoleApp.Model;

namespace ConsoleApp.DAL
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public EmployeeContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }
    }
}
