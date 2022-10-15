using EasyDiscountCalculate.Abstractions;
using EasyDiscountCalculate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Engine.Validation.DiscountRules
{
    public interface IDiscountRule
    {
        ValidationFailure Validate(IDiscount discount);
    }
}
