using System;
using System.Collections.Generic;

namespace FixesAPI
{
    public class APIResponseViewModel
    {
        public int ResponseCode { get; set; }

        public Dictionary<string, string> Message { get; set; }

        public bool Error { get; set; }

        public Dictionary<string, string> ErrorList { get; set; }

    }
}
