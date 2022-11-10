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
    public class EmployeeRL : IEmployeeRL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeRL(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BasicResponse> AddEmployee(AddEmployeeRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Add Employee Successfully";

            try
            {

                EmployeeDetail employeeDetail = new EmployeeDetail()
                {
                    InsertionTime = DateTime.Now,
                    EmployeeID = request.EmployeeID, 
                    EmployeeName = request.EmployeeName, 
                    PhoneNumber = request.PhoneNumber, 
                    Email = request.Email, 
                    Address = request.Address,
                    Designation = request.DesignationId
                };

                await _applicationDbContext.AddAsync(employeeDetail);
                int Result = await _applicationDbContext.SaveChangesAsync();
                if (Result <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong";
                }

            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> DeleteEmployee(int Id)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Delete Employee Successfully";

            try
            {

                var Result = await _applicationDbContext.EmployeeDetail.FindAsync(Id);
                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Not Found";
                    return response;
                }

                await FindLeaveData(Result.EmployeeID);

                _applicationDbContext.EmployeeDetail.Remove(Result);
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

        public async Task<bool> FindLeaveData(string EmployeeID)
        {
            try
            {

                var Result = _applicationDbContext.LeaveDetail.Where(X => X.EmployeeId == EmployeeID).ToList();
                if (Result == null)
                {
                    return false;
                }

                foreach (var data in Result)
                {
                    _applicationDbContext.LeaveDetail.Remove(data);
                    int DeleteResult = await _applicationDbContext.SaveChangesAsync();
                    if (DeleteResult <= 0)
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        public async Task<GetAllEmployeeIdResponse> GetAllEmployeeId()
        {
            GetAllEmployeeIdResponse response = new GetAllEmployeeIdResponse();
            response.IsSuccess = true;
            response.Message = "Successfully";

            try
            {

                var ResultData = _applicationDbContext.EmployeeDetail.ToList();
                if (ResultData.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Employee Id Not Found";
                    return response;
                }



                response.data = new List<GetEmployeeId>();
                ResultData.ForEach(X =>
                {
                    GetEmployeeId getData = new GetEmployeeId();
                    getData.EmployeeId = X.EmployeeID;
                    response.data.Add(getData);
                });

            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : "+ex.Message;
            }

            return response;
        }

        public async Task<GetEmployeeResponse> GetEmployee(GetEmployeeRequest request)
        {
            GetEmployeeResponse response = new GetEmployeeResponse();
            response.IsSuccess = true;
            response.Message = "Get Employee Successfully";

            try
            {

                List<EmployeeDetail> data = new List<EmployeeDetail>();
                data = _applicationDbContext.EmployeeDetail.OrderByDescending(X=>X.Id)
                    .Skip((request.PageNumber - 1) * request.NumberOfRecordPerPage)
                    .Take(request.NumberOfRecordPerPage)
                    .ToList();
                if (data.Count == 0)
                {
                    response.Message = "Data Not Found";
                    return response;
                }

                response.data = new List<EmployeeDetail>();
                data.ForEach(X =>
                {
                    EmployeeDetail getData = new EmployeeDetail();
                    getData.Address = X.Address;
                    getData.Designation = X.Designation;
                    getData.Email = X.Email;
                    getData.EmployeeID = X.EmployeeID;
                    getData.EmployeeName = X.EmployeeName;
                    getData.Id = X.Id;
                    getData.InsertionTime = X.InsertionTime;
                    getData.PhoneNumber = X.PhoneNumber;
                    getData.WorkHour = X.WorkHour;
                    response.data.Add(getData);
                });

                double TotalRecord = _applicationDbContext.EmployeeDetail.Count();
                response.TotalPage = (int)(Math.Ceiling(TotalRecord / request.NumberOfRecordPerPage));

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> UpdateEmployee(UpdateEmployeeRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Update Employee Successfully";

            try
            {

                var EmployeeDetails = await _applicationDbContext.EmployeeDetail.FindAsync(request.Id);

                if (EmployeeDetails == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Employee ID not Found";
                    return response;
                }

                EmployeeDetails.EmployeeID=request.EmployeeID;
                EmployeeDetails.EmployeeName = request.EmployeeName;
                EmployeeDetails.PhoneNumber = request.PhoneNumber;
                EmployeeDetails.Email=request.Email;
                EmployeeDetails.Address=request.Address;
                EmployeeDetails.Designation = request.DesignationId;

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
