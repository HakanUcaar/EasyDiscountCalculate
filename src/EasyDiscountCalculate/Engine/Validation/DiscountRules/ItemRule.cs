using EasyDiscountCalculate.Abstractions;
using EasyDiscountCalculate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Engine.Validation.DiscountRules
{
    public class ItemRule : AbstractDiscountRule
    {
        public ItemRule()
        {
        }

        protected override bool IsValid(IDiscount Context)
        {
            return true;
        }
    }
}
