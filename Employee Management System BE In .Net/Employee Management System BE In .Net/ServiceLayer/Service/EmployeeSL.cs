using CommonLayer.Model;
using RepositoryLayer.Interface;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class EmployeeSL : IEmployeeSL
    {
        private readonly IEmployeeRL _employeeRL;
        public EmployeeSL(IEmployeeRL employeeRL) 
        {
            _employeeRL = employeeRL;
        }

        public async Task<BasicResponse> AddEmployee(AddEmployeeRequest request)
        {
            return await _employeeRL.AddEmployee(request);
        }

        public async Task<BasicResponse> DeleteEmployee(int Id)
        {
            return await _employeeRL.DeleteEmployee(Id);
        }

        public async Task<GetAllEmployeeIdResponse> GetAllEmployeeId()
        {
            return await _employeeRL.GetAllEmployeeId();
        }

        public async Task<GetEmployeeResponse> GetEmployee(GetEmployeeRequest request)
        {
            return await _employeeRL.GetEmployee(request);
        }

        public async Task<BasicResponse> UpdateEmployee(UpdateEmployeeRequest request)
        {
            return await _employeeRL.UpdateEmployee(request);
        }
    }
}
