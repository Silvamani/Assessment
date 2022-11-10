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
    public class HourManagementRL : IHourManagementRL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public HourManagementRL(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BasicResponse> AddHours(AddHoursRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Add Hours Successfully";

            try
            {

                TimeDetail hoursDetail = new TimeDetail()
                {
                    InsertionDate = DateTime.Now,
                    MonthlyTotalHour = request.TotalHours,
                    MonthlyMinHour = request.MinHours
                };

                await _applicationDbContext.AddAsync(hoursDetail);
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

        public async Task<BasicResponse> DeleteHours(int Id)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Delete Hours Successfully";

            try
            {

                var Result = await _applicationDbContext.TimeDetail.FindAsync(Id);
                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Not Found";
                }

                _applicationDbContext.TimeDetail.Remove(Result);
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

        public async Task<GetHoursResponse> GetHours()
        {
            GetHoursResponse response = new GetHoursResponse();
            response.IsSuccess = true;
            response.Message = "Get Hours Successfully";

            try
            {

                response.Data = new TimeDetail(); 
                response.Data = _applicationDbContext.TimeDetail.FirstOrDefault();
                if (response.Data == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Data Not Found";
                    return response;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> UpdateHours(UpdateHoursRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Update Hours Successfully";

            try
            {
                if (request.MinHours == 0 || request.TotalHours == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Value Cannot Be Zero.";
                    return response;
                }

                var UserDetails = await _applicationDbContext.TimeDetail.FindAsync(request.Id);

                if (UserDetails == null)
                {
                    response.IsSuccess = false;
                    response.Message = "ID not Found";
                    return response;
                }

                UserDetails.InsertionDate = DateTime.Now;
                UserDetails.MonthlyMinHour = request.MinHours;
                UserDetails.MonthlyTotalHour = request.TotalHours;

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
