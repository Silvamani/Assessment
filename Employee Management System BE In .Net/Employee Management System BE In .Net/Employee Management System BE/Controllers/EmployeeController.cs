using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_BE.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeSL _employeeSL;
        public EmployeeController(IEmployeeSL employeeSL) 
        {
            _employeeSL = employeeSL;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest request) 
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _employeeSL.AddEmployee(request);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _employeeSL.UpdateEmployee(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee([FromQuery]GetEmployeeRequest request)
        {
            GetEmployeeResponse response = new GetEmployeeResponse();
            try
            {
                response = await _employeeSL.GetEmployee(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeId()
        {
            GetAllEmployeeIdResponse response = new GetAllEmployeeIdResponse();
            try
            {
                response = await _employeeSL.GetAllEmployeeId();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee([FromQuery]int Id)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _employeeSL.DeleteEmployee(Id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }
    
    }
}
