using EasyDiscountCalculate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Engine.Calculation.CalculateRules
{
    internal class QuantityRule : AbstractCalculateRule
    {
        private readonly Document _document;
        public QuantityRule(Document document)
        {
            _document = document;
        }
        public static QuantityRule New(Document document)
        {
            return new QuantityRule(document);
        }
        protected override Calculation Calculate(Discount Context)
        {
            throw new NotImplementedException();
        }
    }
}
