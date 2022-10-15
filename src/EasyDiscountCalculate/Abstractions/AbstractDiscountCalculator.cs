using EasyDiscountCalculate.Engine.Calculation.CalculateRules;
using EasyDiscountCalculate.Engine.Calculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyDiscountCalculate.Common;

namespace EasyDiscountCalculate.Abstractions
{
    public abstract class AbstractDiscountCalculator
    {
        public static Calculation Calculate<T>(Document document) where T : Discount
        {
            var disc = Activator.CreateInstance(typeof(T),document) as Discount;
            var validate = disc.Validate();
            if (validate.IsValid)
            {
                switch (disc.Type)
                {
                    case Common.Enums.DiscountType.Percent:
                        return PercentRule.New(document).CalculateDiscount(disc);
                    case Common.Enums.DiscountType.Price:
                        return PriceRule.New(document).CalculateDiscount(disc);
                    case Common.Enums.DiscountType.Quantity:
                        return QuantityRule.New(document).CalculateDiscount(disc);
                    default:
                        break;
                }
            }

            return new Calculation() { Fails = validate.Errors};
        }
    }
}
