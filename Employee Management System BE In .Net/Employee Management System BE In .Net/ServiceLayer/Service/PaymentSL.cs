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
    public class PaymentSL : IPaymentSL
    {
        private readonly IPaymentRL _paymentRL;
        public PaymentSL(IPaymentRL paymentRL)
        {
            _paymentRL = paymentRL;
        }

        public async Task<BasicResponse> AddPaymentDetail(AddPaymentDetailRequest request)
        {
            return await _paymentRL.AddPaymentDetail(request);
        }

        public async Task<BasicResponse> DeletePaymentDetail(int Id)
        {
            return await _paymentRL.DeletePaymentDetail(Id);
        }

        public async Task<GetPaymentDetailResponse> GetPaymentDetail(GetPaymentDetailRequest request)
        {
            return await _paymentRL.GetPaymentDetail(request);
        }

        public async Task<BasicResponse> UpdatePaymentDetail(UpdatePaymentDetailRequest request)
        {
            return await _paymentRL.UpdatePaymentDetail(request);
        }
    }
}
