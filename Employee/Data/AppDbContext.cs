using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Employee.Models;

namespace Employee.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() : base("name=DefaultConnection")
        {
        }

        // Tambahkan properti DbSet untuk setiap entitas yang ingin Anda gunakan

        //Employee
        public DbSet<Models.Employees> Employees { get; set; }
        public DbSet<Models.Positon> Positons { get; set; }
        public DbSet<Models.Department> Departments { get; set; }
        public DbSet<Models.Allowance> Allowances { get; set; }
        public DbSet<Models.Employee_Allowance> Employee_Allowances { get; set; }

        //Overtime
        public DbSet<Models.Overtime> Overtime { get; set; }

    }
}