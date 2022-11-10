using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IPaymentSL
    {
        public Task<BasicResponse> AddPaymentDetail(AddPaymentDetailRequest request);
        public Task<BasicResponse> UpdatePaymentDetail(UpdatePaymentDetailRequest request);
        public Task<GetPaymentDetailResponse> GetPaymentDetail(GetPaymentDetailRequest request);
        public Task<BasicResponse> DeletePaymentDetail(int Id);
    }
}
