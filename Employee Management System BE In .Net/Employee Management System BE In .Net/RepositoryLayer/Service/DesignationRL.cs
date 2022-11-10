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
    public class DesignationRL : IDesignationRL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public DesignationRL(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BasicResponse> AddDesignation(AddDesignationRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Add Designation Successfully";

            try
            {

                DesignationDetail designationDetail = new DesignationDetail()
                {
                    InsertionDate = DateTime.Now,
                    DesignationName= request.DesignationName
                };

                await _applicationDbContext.AddAsync(designationDetail);
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

        public async Task<BasicResponse> DeleteDesignation(int Id)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Delete Designation Successfully";

            try
            {

                var Result = await _applicationDbContext.DesignationDetail.FindAsync(Id);
                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Not Found";
                    return response;
                }

                await FlushAllEmployeeAssignDesignation(Result.DesignationName);

                _applicationDbContext.DesignationDetail.Remove(Result);
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

        public async Task<bool> FlushAllEmployeeAssignDesignation(string Designation)
        {
            
            try
            {

                var Result =  _applicationDbContext.EmployeeDetail
                    .Where(X=>X.Designation.ToLower() == Designation.ToLower()).ToList();

                if (Result.Count == 0)
                {
                    return true;
                }

                foreach(var data in Result)
                {
                    var EmployeeDetail = await _applicationDbContext.EmployeeDetail.FindAsync(data.Id);
                    if(EmployeeDetail==null)
                    {
                        continue;
                    }

                    EmployeeDetail.Designation = "None";
                    await _applicationDbContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        public async Task<GetDesignationResponse> GetAllDesignation()
        {
            GetDesignationResponse response = new GetDesignationResponse();
            response.IsSuccess = true;
            response.Message = "Get Designation Successfully";

            try
            {

                response.data = new List<DesignationDetail>();
                response.data = _applicationDbContext.DesignationDetail.ToList();
                if (response.data.Count == 0)
                {
                    response.Message = "Data Not Found";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<GetDesignationResponse> GetDesignation(GetDesignationRequest request)
        {
            GetDesignationResponse response = new GetDesignationResponse();
            response.IsSuccess = true;
            response.Message = "Get Designation Successfully";

            try
            {

               await DesignationCount();

                response.data = new List<DesignationDetail>();
                response.data = _applicationDbContext.DesignationDetail.OrderByDescending(X=>X.Id)
                    .Skip((request.PageNumber-1)*request.NumberOfRecordPerPage)
                    .Take(request.NumberOfRecordPerPage)
                    .ToList();

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

        public async Task<bool> DesignationCount()
        {
            try
            {
                var ResultData = _applicationDbContext.DesignationDetail.ToList();
                if (ResultData.Count == 0)
                {
                    return false;
                }

                foreach(DesignationDetail X in ResultData)
                {
                    int count = _applicationDbContext.EmployeeDetail.Where(X1 => X1.Designation == X.DesignationName).Count();
                    var DesignationResult = _applicationDbContext.DesignationDetail.Where(X1 => X1.DesignationName == X.DesignationName).FirstOrDefault();
                    if (DesignationResult == null)
                    {
                        continue;
                    }

                    DesignationResult.EmployeeCount = count;
                    await _applicationDbContext.SaveChangesAsync();
                    
                }

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        public async Task<BasicResponse> UpdateDesignation(UpdateDesignationRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Update Designation Successfully";

            try
            {

                var EmployeeDetails = await _applicationDbContext.DesignationDetail.FindAsync(request.Id);

                if (EmployeeDetails == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Designation ID not Found";
                    return response;
                }

                EmployeeDetails.DesignationName = request.DesignationName;

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
