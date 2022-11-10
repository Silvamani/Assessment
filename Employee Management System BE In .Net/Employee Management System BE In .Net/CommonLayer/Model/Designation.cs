using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class GetDesignationResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int TotalPage { get; set; }
        public List<DesignationDetail> data { get; set; }
    }

    public class AddDesignationRequest
    {
        public string DesignationName { get; set; }
    }


    public class UpdateDesignationRequest
    {
        public int Id { get; set; }
        public string DesignationName { get; set; }
    }

    public class GetDesignationRequest
    {
        [Required]
        public int PageNumber { get; set; }
        [Required]
        public int NumberOfRecordPerPage { get; set; }
    }
}
