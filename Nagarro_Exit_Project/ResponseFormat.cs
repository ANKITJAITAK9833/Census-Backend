using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nagarro_Exit_Project
{
    public class ResponseFormat<T>
    {
        public T Data { get; set;}
        public  string message { get; set; }
        public bool success { get; set; }
    }
}