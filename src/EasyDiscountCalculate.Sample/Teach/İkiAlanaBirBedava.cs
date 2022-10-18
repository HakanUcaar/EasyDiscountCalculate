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
    public class İkiAlanaBirBedava : Discount
    {
        public İkiAlanaBirBedava(Document document) : base(document)
        {
            DiscountValue = 100;
            Type = Common.Enums.DiscountType.Percent;
            Domain = Common.Enums.DomainType.DocumentLine;
            TriggerValue = 3;
            EffectedValue = 1;

            NewRule(new MyItemRule(document));
        }
    }

    public class MyItemRule : AbstractDiscountRule
    {
        private readonly Document _document;
        public MyItemRule(Document document)
        {
            _document = document;
        }
        protected override bool IsValid(IDiscount Context)
        {
            return _document.Lines.Count > 2;
        }
    }
}
