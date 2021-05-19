using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExperience.Test.Models
{
    public class APIResult
    {
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public int TotalRecords { get; set; }
        public Object data { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesciption { get; set; }
    }
}