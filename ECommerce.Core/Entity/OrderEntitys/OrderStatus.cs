using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entity.OrderEntitys
{
    public enum OrderStatus
    {
        [EnumMember(Value ="Pending")]

        pending,
        [EnumMember(Value ="Payment Recieved")]

        PaymentSuccess,
        [EnumMember(Value ="Payment Failure")]
        PaymentFailure,
    }
}
