using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class AddEmployeeRequest
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DesignationId { get; set; }
    }

    public class BasicResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class UpdateEmployeeRequest
    {
        public int Id { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DesignationId { get; set; }
    }

    public class GetEmployeeRequest
    {
        public int PageNumber { get; set; }
        public int NumberOfRecordPerPage { get; set; }
    }

    public class GetEmployeeResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int TotalPage { get; set; }
        public List<EmployeeDetail> data { get; set; }
    }

    public class GetAllEmployeeIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<GetEmployeeId> data { get; set; }
    }

    public class GetEmployeeId
    {
        public string EmployeeId { get; set; }
    }
}
