using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IHourManagementRL
    {
        public Task<BasicResponse> AddHours(AddHoursRequest request);
        public Task<BasicResponse> UpdateHours(UpdateHoursRequest request);
        public Task<BasicResponse> DeleteHours( int Id);
        public Task<GetHoursResponse> GetHours();
    }
}
