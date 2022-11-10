using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class UserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public DateTime InsertionDate { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class EmployeeDetail
    {
        //EmployeeID, EmployeeName, PhoneNumber, Email, Address
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime InsertionTime { get; set; } = DateTime.Now;
        [Required]
        public string EmployeeID { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public long WorkHour { get; set; } = 0;
    }

    public class TimeDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime InsertionDate { get; set; }
        public long MonthlyTotalHour { get; set; }
        public long MonthlyMinHour { get; set; }

    }

    public class DesignationDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime InsertionDate { get; set; }
        [Required]
        public string DesignationName { get; set; }
        public int EmployeeCount { get; set; }
        public long Payment { get; set; }
    }


    public class LeaveDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime InsertionDate { get; set; }
        public string EmployeeId { get; set; }
        public string Type { get; set; }
        public string FromLeaveDate { get; set; }
        public string ToLeaveDate { get; set; }
        public string Reason { get; set; }
    }

}
