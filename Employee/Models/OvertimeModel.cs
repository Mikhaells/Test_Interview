using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Employee.Models
{

    [Table("Overtime")]
    public class Overtime
    {
        public int Id { get; set; }
        public string NIK { get; set; }    
        public DateTime TimeStart { get; set; }
        public DateTime TimeFinish {  get; set; }   
        public int ActualHours { get; set; }    
        public int CalculatedHours { get; set; }
         
    }

    public class OvertimeModel
    {

    }

    

}