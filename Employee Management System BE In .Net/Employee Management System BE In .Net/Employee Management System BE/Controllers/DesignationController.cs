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
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationSL _designationSL;
        public DesignationController(IDesignationSL designationSL)
        {
            _designationSL = designationSL;
        }

        [HttpPost]
        public async Task<IActionResult> AddDesignation(AddDesignationRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _designationSL.AddDesignation(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateDesignation(UpdateDesignationRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _designationSL.UpdateDesignation(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetDesignation([FromQuery]GetDesignationRequest request)
        {
            GetDesignationResponse response = new GetDesignationResponse();
            try
            {
                response = await _designationSL.GetDesignation(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDesignation()
        {
            GetDesignationResponse response = new GetDesignationResponse();
            try
            {
                response = await _designationSL.GetAllDesignation();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteDesignation([FromQuery] int Id)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _designationSL.DeleteDesignation(Id);
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
