using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IEmployeeSL
    {
        public Task<BasicResponse> AddEmployee(AddEmployeeRequest request);
        public Task<BasicResponse> UpdateEmployee(UpdateEmployeeRequest request);
        public Task<GetEmployeeResponse> GetEmployee(GetEmployeeRequest request);
        public Task<GetAllEmployeeIdResponse> GetAllEmployeeId();
        public Task<BasicResponse> DeleteEmployee(int Id);
    }
}
