using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class AddHoursRequest
    {
        public long TotalHours { get; set; }
        public long MinHours { get; set; }
    }

    public class UpdateHoursRequest
    {
        public int Id { get; set; }
        public long TotalHours { get; set; }
        public long MinHours { get; set; }
    }

    public class GetHoursResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int TotalPage { get; set; }

        public TimeDetail Data { get; set; }
    }
}
