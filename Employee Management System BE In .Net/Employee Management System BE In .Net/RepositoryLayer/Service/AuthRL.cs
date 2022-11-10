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
    public class AuthRL : IAuthRL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AuthRL(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            SignInResponse response = new SignInResponse();
            response.IsSuccess = true;
            response.Message = "Sign In Successfully";

            try
            {

                var Result = _applicationDbContext
                    .UserDetail
                    .Where(X => X.UserName.ToLower() == request.UserName.ToLower() &&
                    X.Password == request.Password).FirstOrDefault();


                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Sign In Failed";
                    return response;
                }

                response.UserId = Result.UserID;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> SignUp(SignUpRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            
            response.Message = "Register Successfully";

            try
            {
                bool FoundResult = _applicationDbContext
                                   .UserDetail
                                   .Any(X => X.UserName.ToLower() == request.UserName.ToLower());
                if (FoundResult)
                {
                    response.IsSuccess = false;
                    response.Message = "UserName or Email Already Exist";
                    return response;
                }

                UserDetail userDetail = new UserDetail()
                {
                    InsertionDate = DateTime.Now,
                    UserName = request.UserName,
                    Password = request.Password
                };

                await _applicationDbContext.AddAsync(userDetail);
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
