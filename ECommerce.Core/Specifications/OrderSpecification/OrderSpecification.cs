using ECommerce.Core.Entity.OrderEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Specifications.OrderSpecification
{
    public class OrderSpecification: Specification<Order>
    {
       
        public OrderSpecification(string buyerEmail):base(o=>o.BuyerEmail==buyerEmail)
        {
            includes.Add(o => o.Items);
            includes.Add(o => o.DeliveryMethod);
            OrderByDesc = o => o.OrderDate;
        }
        public OrderSpecification(string buyerEmail , int id): base(o=> o.Id==id && o.BuyerEmail == buyerEmail) 
        {
            includes.Add(o => o.Items);
            includes.Add(o => o.DeliveryMethod);

        }
    }
}
