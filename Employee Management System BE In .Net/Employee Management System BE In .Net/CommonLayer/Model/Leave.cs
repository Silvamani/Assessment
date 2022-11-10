using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class AddLeaveDetailRequest
    {
        [Required]
        public string EmployeeId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string FromleaveDate { get; set; }
        [Required]
        public string ToleaveDate { get; set; }
        public string Reason { get; set; }
    }

    public class UpdateLeaveDetailRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string FromLeaveDate { get; set; }
        [Required]
        public string ToLeaveDate { get; set; }
        public string Reason { get; set; }
    }

    public class GetLeaveDetailRequest
    {
        [Required]
        public int PageNumber { get; set; }
        [Required]
        public int NumberOfRecordPerPage { get; set; }
    }

    public class GetLeaveDetailResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int TotalPage { get; set; }
        public List<LeaveDetail> data { get; set; }
    }
}
