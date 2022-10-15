using EasyDiscountCalculate.Abstractions;
using EasyDiscountCalculate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Engine.Validation.DiscountRules
{
    public abstract class AbstractDiscountRule : IDiscountRule
    {
        public AbstractDiscountRule()
        {
        }

        public ValidationFailure Validate(IDiscount Context)
        {
            if (IsValid(Context))
            {
                return null;
            }

            return CreateValidationError(Context);
        }
        protected abstract bool IsValid(IDiscount Context);
        protected virtual ValidationFailure CreateValidationError(IDiscount Context)
        {
            var failure = new ValidationFailure(this.GetType().Name + " koşulu sağlanamadı");

            return failure;
        }
    }
}
