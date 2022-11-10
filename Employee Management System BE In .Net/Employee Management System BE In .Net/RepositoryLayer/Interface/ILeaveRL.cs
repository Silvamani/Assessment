using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface ILeaveRL
    {
        public Task<BasicResponse> AddLeaveDetail(AddLeaveDetailRequest request);
        public Task<BasicResponse> UpdateLeaveDetail(UpdateLeaveDetailRequest request);
        public Task<GetLeaveDetailResponse> GetLeaveDetail(GetLeaveDetailRequest request);
        public Task<BasicResponse> DeleteLeaveDetail(int Id);
    }
}
