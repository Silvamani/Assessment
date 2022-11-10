using CommonLayer.Model;
using RepositoryLayer.Interface;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class LeaveSL : ILeaveSL
    {
        private readonly ILeaveRL _leaveRL;
        public LeaveSL(ILeaveRL leaveRL) 
        {
            _leaveRL = leaveRL;
        }

        public async Task<BasicResponse> AddLeaveDetail(AddLeaveDetailRequest request)
        {
            return await _leaveRL.AddLeaveDetail(request);
        }

        public async Task<BasicResponse> DeleteLeaveDetail(int Id)
        {
            return await _leaveRL.DeleteLeaveDetail(Id);
        }

        public async Task<GetLeaveDetailResponse> GetLeaveDetail(GetLeaveDetailRequest request)
        {
            return await _leaveRL.GetLeaveDetail(request);
        }

        public async Task<BasicResponse> UpdateLeaveDetail(UpdateLeaveDetailRequest request)
        {
            return await _leaveRL.UpdateLeaveDetail(request);
        }
    }
}
