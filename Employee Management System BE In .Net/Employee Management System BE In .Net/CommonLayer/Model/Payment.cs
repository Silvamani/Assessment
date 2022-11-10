using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class AddPaymentDetailRequest
    {
        [Required]
        public string DesignationID { get; set; }
        [Required]
        public int PaymentAmount { get; set; }
    }

    public class UpdatePaymentDetailRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string DesignationID { get; set; }
        [Required]
        public int PaymentAmount { get; set; }
    }

    public class GetPaymentDetailRequest
    {
        [Required]
        public int PageNumber { get; set; }
        [Required]
        public int NumberOfRecordPerPage { get; set; }
    }

    public class GetPaymentDetailResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int TotalPage { get; set; }
        public List<DesignationDetail> data { get; set; }
    }
}
