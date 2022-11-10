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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentSL _paymentSL;
        public PaymentController(IPaymentSL paymentSL) 
        {
            _paymentSL = paymentSL;
        }


        [HttpPost]
        public async Task<IActionResult> AddPaymentDetail(AddPaymentDetailRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _paymentSL.AddPaymentDetail(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePaymentDetail(UpdatePaymentDetailRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _paymentSL.UpdatePaymentDetail(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentDetail([FromQuery] GetPaymentDetailRequest request)
        {
            GetPaymentDetailResponse response = new GetPaymentDetailResponse();
            try
            {
                response = await _paymentSL.GetPaymentDetail(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePaymentDetail([FromQuery] int Id)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _paymentSL.DeletePaymentDetail(Id);
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
