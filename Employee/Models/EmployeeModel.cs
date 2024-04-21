using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Models
{

    public class Employees
    {
        public int Id { get; set; }
        public string NIK { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
    }

    public class Positon
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Allowance
    {
        public int Id { get; set; } 
        public string Desc { get; set; }    
    }

    public class Employee_Allowance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int AllowanceId { get; set; }
    }


    public class EmployeeModel
    {
        public int Id { get; set; }
        public string NIK { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
    }

    public class Employee_AllowanceModel
    {
        public int Id { get; set; }
        public string Employee { get; set; }
        public string Allowance { get; set; }
    }

}