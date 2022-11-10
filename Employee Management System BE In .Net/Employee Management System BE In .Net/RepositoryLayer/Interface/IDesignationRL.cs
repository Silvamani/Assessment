using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IDesignationRL
    {
        public Task<BasicResponse> AddDesignation(AddDesignationRequest request);
        public Task<BasicResponse> UpdateDesignation(UpdateDesignationRequest request);
        public Task<GetDesignationResponse> GetDesignation(GetDesignationRequest request);
        public Task<GetDesignationResponse> GetAllDesignation();
        public Task<BasicResponse> DeleteDesignation(int Id);
    }
}
