using EasyDiscountCalculate.Abstractions;
using EasyDiscountCalculate.Common;
using EasyDiscountCalculate.Engine.Validation.DiscountRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Engine.Validation
{
    public abstract class AbstractDiscountValidator<T> : IDiscountValidator where T : IDiscount
    {
        private IDocument Document { get; set; }
        public List<IDiscountRule> Rules { get; set; } = new List<IDiscountRule>();
        public List<ValidationFailure> Fails { get; set; } = new List<ValidationFailure>();
        public AbstractDiscountValidator()
        {

        }
        public AbstractDiscountValidator(IDocument document)
        {
            Document = document;
        }

        protected void AddRule(IDiscountRule rule)
        {
            Rules.Add(rule);
        }
        public IDiscountRule NewRule(IDiscountRule Rule)
        {
            AddRule(Rule);
            return Rule;
        }

        public virtual ValidationResult Validate()
        {
            return new ValidationResult();
        }
    }
}
