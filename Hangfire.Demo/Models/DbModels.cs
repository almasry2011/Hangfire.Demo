using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.Demo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        ICollection<Employee> Employees { get; set; }
    }


    public class AppdbContext:DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
        { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }

}
