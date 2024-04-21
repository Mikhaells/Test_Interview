using Employee.Data;
using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Business
{
    public class Overtime
    {
        private AppDbContext db = new AppDbContext();

        public List<Models.Overtime> GetOvertime()
        {
            List<Models.Overtime> _res = new List<Models.Overtime>();
            _res = db.Overtime.ToList();
            return _res;
        }

        public Models.GeneralReturnModel InserOvertime(string NIK,DateTime StartTime,DateTime FinishTime,int ActualHours)
        {
            Models.GeneralReturnModel _res = new Models.GeneralReturnModel();
            _res = db.Database.SqlQuery<GeneralReturnModel>($@"EXEC Local.dbo.sp_InsertOvertime '{NIK}','{StartTime}','{FinishTime}','{ActualHours}'").FirstOrDefault();
            return _res; 
        }

        public Models.GeneralReturnModel UpdateOvertime(string NIK, DateTime StartTime, DateTime FinishTime, int ActualHours)
        {
            Models.GeneralReturnModel _res = new Models.GeneralReturnModel();
            _res = db.Database.SqlQuery<GeneralReturnModel>($@"EXEC Local.dbo.sp_UpdateOverTime '{NIK}','{StartTime}','{FinishTime}','{ActualHours}'").FirstOrDefault();
            return _res;
        }

        public Models.GeneralReturnModel DeleteOvertime(string NIK)
        {
            Models.GeneralReturnModel _res = new Models.GeneralReturnModel();
            _res = db.Database.SqlQuery<GeneralReturnModel>($@"EXEC Local.dbo.sp_DeleteOvertime '{NIK}'").FirstOrDefault();
            return _res;
        }


    }
}