using EasyDiscountCalculate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Engine.Calculation.CalculateRules
{
    internal class PriceRule : AbstractCalculateRule
    {
        private readonly Document _document;
        public PriceRule(Document document)
        {
            _document = document;
        }
        public static PriceRule New(Document document)
        {
            return new PriceRule(document);
        }
        protected override Calculation Calculate(Discount Context)
        {
            throw new NotImplementedException();
        }
    }
}
