using EasyDiscountCalculate.Abstractions;
using EasyDiscountCalculate.Common;
using EasyDiscountCalculate.Engine.Validation.DiscountRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Sample.Extend
{
    public class BirAlanaBirBedava : Discount
    {
        public BirAlanaBirBedava(Document document) : base(document)
        {
            DiscountValue = 100;
            Type = Common.Enums.DiscountType.Percent;
            Domain = Common.Enums.DomainType.DocumentLine;
            TriggerValue = 2;
            EffectedValue = 1;
        }
    }
}
