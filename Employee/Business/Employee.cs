using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Employee.Data;
using Employee.Models;

namespace Employee.Business
{
    public class Employee
    {
        private AppDbContext db = new AppDbContext();  

        public List<Employees> GetEmployees()
        {
            List<Employees> res = new List<Employees>();
            res =  db.Employees.ToList(); 
            return res;
        }

        public List<EmployeeModel> GetEmployeesBySP()
        {
            List<EmployeeModel> res = new List<EmployeeModel>();
            res = db.Database.SqlQuery<EmployeeModel>(@"EXEC Local.dbo.sp_GetEmployee").ToList();
            return res;

        }

        public EmployeeModel GetEmployeesById(int Id)
        {
            EmployeeModel res = new EmployeeModel();
            res = db.Database.SqlQuery<EmployeeModel>($@"select e.Id,NIK,e.[Name],p.[Name] as Position ,d.[Name] as Department 
                                                        from Local.dbo.Employees e
                                                        inner join Local.dbo.Positon p on p.Id = e.PositionId
                                                        inner join Local.dbo.Department d on d.Id = e.DepartmentId
                                                        where e.Id = {Id}").FirstOrDefault();
            return res;
        }

        public List<Models.Employee_AllowanceModel> GetAllowanceDetailById(int Id)
        {
            List<Models.Employee_AllowanceModel> res = new List<Models.Employee_AllowanceModel>();
            res = db.Database.SqlQuery<Employee_AllowanceModel>($@"select EA.Id, E.Name AS Employee, [A].[Desc] Allowance
                                                                  from Local.dbo.Employee_Allowance EA
                                                                  INNER JOIN Local.dbo.Employees E ON E.Id = EA.EmployeeId
                                                                  INNER JOIN Local.dbo.Allowance A ON A.Id = EA.AllowanceId
                                                                  WHERE EA.EmployeeId = {Id}").ToList();
            return res;
        }

        public List<Models.Positon> GetPosition()
        {
             List<Models.Positon> _res = new List<Models.Positon>();
            _res = db.Database.SqlQuery<Positon>("select * from Local.dbo.Positon").ToList();
            return _res;
        }

        public List<Models.Department> GetDepartment()
        {
            List<Models.Department> _res = new List<Models.Department>();       
            _res = db.Database.SqlQuery<Department>("select * from Local.dbo.Department").ToList();
            return _res;
        }

        public List<Models.Allowance> GetAllowance() 
        {
            List<Models.Allowance> _res = new List<Models.Allowance>();
            _res = db.Database.SqlQuery<Allowance>("select * from Local.dbo.Allowance ").ToList();
            return _res;
        }


        public Models.GeneralReturnModel InsertEmployeeData(Models.Employees data,string Allowance)
        {
            Models.GeneralReturnModel _res = new Models.GeneralReturnModel();
            _res = db.Database.SqlQuery<Models.GeneralReturnModel>($"EXEC Local.dbo.sp_InsertEmployee '{data.NIK}','{data.Name}','{data.DepartmentId}','{data.PositionId}','{Allowance}'").FirstOrDefault();
            return _res; 
        }
        public Models.GeneralReturnModel UpdateEmployeeData(Models.Employees data, string Allowance)
        {
            Models.GeneralReturnModel _res = new Models.GeneralReturnModel();
            _res = db.Database.SqlQuery<Models.GeneralReturnModel>($"EXEC Local.dbo.sp_UpdateEmployee '{data.NIK}','{data.Name}','{data.DepartmentId}','{data.PositionId}','{Allowance}'").FirstOrDefault();
            return _res;
        }
        public Models.GeneralReturnModel DeleteEmployeeData(int Id)
        {
            Models.GeneralReturnModel _res = new Models.GeneralReturnModel();
            _res = db.Database.SqlQuery<Models.GeneralReturnModel>($"EXEC Local.dbo.sp_DeleteEmployee '{Id}'").FirstOrDefault();
            return _res;
        }

    }
}