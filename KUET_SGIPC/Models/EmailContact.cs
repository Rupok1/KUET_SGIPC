﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KUET_SGIPC.Models
{
    public class EmailContact
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}