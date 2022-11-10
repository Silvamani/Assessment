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
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveSL _leaveSL;
        public LeaveController(ILeaveSL leaveSL) 
        {
            _leaveSL = leaveSL;
        }

        [HttpPost]
        public async Task<IActionResult> AddLeaveDetail(AddLeaveDetailRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _leaveSL.AddLeaveDetail(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateLeaveDetail(UpdateLeaveDetailRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _leaveSL.UpdateLeaveDetail(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaveDetail([FromQuery] GetLeaveDetailRequest request)
        {
            GetLeaveDetailResponse response = new GetLeaveDetailResponse();
            try
            {
                response = await _leaveSL.GetLeaveDetail(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLeaveDetail([FromQuery] int Id)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _leaveSL.DeleteLeaveDetail(Id);
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
