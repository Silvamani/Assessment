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
    public class LeaveRL : ILeaveRL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public LeaveRL(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BasicResponse> AddLeaveDetail(AddLeaveDetailRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Add Leave Successfully";

            try
            {

                LeaveDetail leaveDetail = new LeaveDetail()
                {
                    InsertionDate = DateTime.Now,
                    EmployeeId = request.EmployeeId,
                    Type = request.Type, // Sick Leave, Annual Leave
                    FromLeaveDate = request.FromleaveDate,
                    ToLeaveDate = request.ToleaveDate,
                    Reason = request.Reason
                };

                await _applicationDbContext.AddAsync(leaveDetail);
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

        public async Task<BasicResponse> DeleteLeaveDetail(int Id)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Delete Leave Successfully";

            try
            {

                var Result = await _applicationDbContext.LeaveDetail.FindAsync(Id);
                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Not Found";
                    return response;
                }

                _applicationDbContext.LeaveDetail.Remove(Result);
                int DeleteResult = await _applicationDbContext.SaveChangesAsync();
                if (DeleteResult <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something went Wrong";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<GetLeaveDetailResponse> GetLeaveDetail(GetLeaveDetailRequest request)
        {
            GetLeaveDetailResponse response = new GetLeaveDetailResponse();
            response.IsSuccess = true;
            response.Message = "Get Leave Successfully";

            try
            {

                response.data = new List<LeaveDetail>();
                response.data = _applicationDbContext.LeaveDetail.OrderByDescending(X=>X.Id)
                    .Skip((request.PageNumber-1)*request.NumberOfRecordPerPage)
                    .Take(request.NumberOfRecordPerPage).ToList();
                if (response.data.Count == 0)
                {
                    response.data = null;
                    response.IsSuccess = false;
                    response.Message = "Data Not Found";
                    return response;
                }

                double TotalRecord = _applicationDbContext.LeaveDetail.Count();
                response.TotalPage = (int)(Math.Ceiling(TotalRecord / request.NumberOfRecordPerPage));

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> UpdateLeaveDetail(UpdateLeaveDetailRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Update Leave Successfully";

            try
            {

                var LeaveDetail = await _applicationDbContext.LeaveDetail.FindAsync(request.Id);
                if (LeaveDetail == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Leave ID not Found";
                    return response;
                }

                LeaveDetail.EmployeeId = request.EmployeeId;
                LeaveDetail.FromLeaveDate = request.FromLeaveDate;
                LeaveDetail.ToLeaveDate = request.ToLeaveDate;
                LeaveDetail.Reason = request.Reason;
                LeaveDetail.Type = request.Type;

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
