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
    public class HourManagementController : ControllerBase
    {
        private readonly IHourManagementSL _hourManagementSL;
        public HourManagementController(IHourManagementSL hourManagementSL)
        {
            _hourManagementSL = hourManagementSL;
        }

        [HttpPost]
        public async Task<IActionResult> AddHours(AddHoursRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _hourManagementSL.AddHours(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateHours(UpdateHoursRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _hourManagementSL.UpdateHours(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetHours()
        {
            GetHoursResponse response = new GetHoursResponse();
            try
            {
                response = await _hourManagementSL.GetHours();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHours([FromQuery] int Id)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _hourManagementSL.DeleteHours(Id);
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
