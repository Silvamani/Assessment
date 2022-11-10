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
    public class DesignationSL : IDesignationSL
    {
        private readonly IDesignationRL _designationRL;
        public DesignationSL(IDesignationRL designationSL)
        {
            _designationRL = designationSL;
        }
        public async Task<BasicResponse> AddDesignation(AddDesignationRequest request)
        {
            return await _designationRL.AddDesignation(request);
        }

        public async Task<BasicResponse> DeleteDesignation(int Id)
        {
            return await _designationRL.DeleteDesignation(Id);
        }

        public async Task<GetDesignationResponse> GetAllDesignation()
        {
            return await _designationRL.GetAllDesignation();
        }

        public async Task<GetDesignationResponse> GetDesignation(GetDesignationRequest request)
        {
            return await _designationRL.GetDesignation(request);
        }

        public async Task<BasicResponse> UpdateDesignation(UpdateDesignationRequest request)
        {
            return await _designationRL.UpdateDesignation(request);
        }
    }
}
