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
    public class BinLiraÜzerineSepeteYüzdeYirmi : Discount
    {
        public BinLiraÜzerineSepeteYüzdeYirmi(Document document) : base(document)
        {
            DiscountValue = 20;
            Type = Common.Enums.DiscountType.Percent;
            Domain = Common.Enums.DomainType.Document;

            NewRule(new BinLiraKuralı(document));
        }        
    }

    public class BinLiraKuralı : AbstractDiscountRule
    {
        private readonly Document _document;
        public BinLiraKuralı(Document document)
        {
            _document = document;
        }
        protected override bool IsValid(IDiscount Context)
        {
            return _document.DocTotal > 1000;
        }
    }
}
