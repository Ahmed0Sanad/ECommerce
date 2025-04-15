using ECommerce.Core.Entity.OrderEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Specifications.OrderSpecification
{
    public class OrderWithPaymentIntentIdSpecification:Specification<Order>
    {
        public OrderWithPaymentIntentIdSpecification(string paymentIntentId):base(o=>o.PaymentIntentId==paymentIntentId)
        {
            
        }
    }
}
