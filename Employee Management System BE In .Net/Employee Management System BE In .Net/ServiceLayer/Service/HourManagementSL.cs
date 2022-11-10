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
    public class HourManagementSL : IHourManagementSL
    {
        private readonly IHourManagementRL _hourManagementRL;
        public HourManagementSL(IHourManagementRL hourManagementRL)
        {
            _hourManagementRL = hourManagementRL;
        }

        public async Task<BasicResponse> AddHours(AddHoursRequest request)
        {
            return await _hourManagementRL.AddHours(request);
        }

        public async Task<BasicResponse> DeleteHours(int Id)
        {
            return await _hourManagementRL.DeleteHours(Id);
        }

        public async Task<GetHoursResponse> GetHours()
        {
            return await _hourManagementRL.GetHours();
        }

        public async Task<BasicResponse> UpdateHours(UpdateHoursRequest request)
        {
            return await _hourManagementRL.UpdateHours(request);
        }
    }
}
