using EasyDiscountCalculate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Engine.Calculation.CalculateRules
{
    public abstract class AbstractCalculateRule : ICalculateRule
    {
        public AbstractCalculateRule()
        {

        }
        public Calculation CalculateDiscount(Discount Context)
        {
            return Calculate(Context);
        }
        protected abstract Calculation Calculate(Discount Context);
    }
}
