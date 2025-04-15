using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Helper
{
   public  class StripeResponseServ
    {
        
        public HttpStatusCode statusCode { get; set; }
        public string? ErrorMassage { get; set; }
        public string? Url { get; set; }
    }
}
