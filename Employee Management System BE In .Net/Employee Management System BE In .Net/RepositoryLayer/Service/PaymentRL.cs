using CommonLayer;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class PaymentRL : IPaymentRL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PaymentRL(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BasicResponse> AddPaymentDetail(AddPaymentDetailRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Add Payment Successfully";

            try
            {

                /*PaymentDetail paymentDetail = new PaymentDetail()
                {
                    InsertionDate = DateTime.Now,
                    Designation = request.DesignationID,
                    PaymentAmount = request.PaymentAmount
                };

                await _applicationDbContext.AddAsync(paymentDetail);
                int Result = await _applicationDbContext.SaveChangesAsync();
                if (Result <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong";
                }
                */

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> DeletePaymentDetail(int Id)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Delete Payment Successfully";

            try
            {

                var Result = await _applicationDbContext.DesignationDetail.FindAsync(Id);
                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Not Found";
                    return response;
                }

                Result.Payment = 0;
                int Result1 = await _applicationDbContext.SaveChangesAsync();
                if (Result1 <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<GetPaymentDetailResponse> GetPaymentDetail(GetPaymentDetailRequest request)
        {
            GetPaymentDetailResponse response = new GetPaymentDetailResponse();
            response.IsSuccess = true;
            response.Message = "Get Payment Successfully";

            try
            {

                response.data = new List<DesignationDetail>();
                response.data = _applicationDbContext.DesignationDetail
                    .OrderByDescending(X=>X.Id)
                    .Skip((request.PageNumber - 1) * request.NumberOfRecordPerPage)
                    .Take(request.NumberOfRecordPerPage).ToList();
                if (response.data.Count == 0)
                {
                    response.data = null;
                    response.IsSuccess = false;
                    response.Message = "Data Not Found";
                    return response;
                }

                double TotalRecord = _applicationDbContext.DesignationDetail.Count();
                response.TotalPage = (int)(Math.Ceiling(TotalRecord / request.NumberOfRecordPerPage));

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> UpdatePaymentDetail(UpdatePaymentDetailRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Update Payment Successfully";

            try
            {

                var PaymentDetail = await _applicationDbContext.DesignationDetail.FindAsync(request.Id);

                if (PaymentDetail == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Employee ID not Found";
                    return response;
                }

                //PaymentDetail.Payment = request.DesignationID;
                PaymentDetail.Payment = request.PaymentAmount;

                int Result = await _applicationDbContext.SaveChangesAsync();
                if (Result <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }
    }
}
