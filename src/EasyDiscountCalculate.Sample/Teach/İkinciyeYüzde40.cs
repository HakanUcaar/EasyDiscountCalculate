using EasyDiscountCalculate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Sample.Extend
{
    public class İkinciyeYüzde40 : Discount
    {
        public İkinciyeYüzde40(Document document) : base(document)
        {
            DiscountValue = 40;
            Type = Common.Enums.DiscountType.Percent;
            Domain = Common.Enums.DomainType.DocumentLine;
            TriggerValue = 2;
            EffectedValue = 1;
        }
    }
}
