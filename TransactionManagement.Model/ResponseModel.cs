using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TransactionManagement.Model
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
