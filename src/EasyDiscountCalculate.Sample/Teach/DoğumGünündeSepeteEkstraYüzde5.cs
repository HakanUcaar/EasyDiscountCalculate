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
    public class DoğumGünündeSepeteEkstraYüzde5 : Discount
    {
        public DoğumGünündeSepeteEkstraYüzde5(Document document) : base(document)
        {
            DiscountValue = 5;
            Type = Common.Enums.DiscountType.Percent;
            Domain = Common.Enums.DomainType.Document;

            NewRule(new DoğumGünüKuralı(document));
        }
    }

    public class DoğumGünüKuralı : AbstractDiscountRule
    {
        private readonly Document _document;
        public DoğumGünüKuralı(Document document)
        {
            _document = document;
        }
        protected override bool IsValid(IDiscount Context)
        {
            return _document.BusinessPartner.BirthDate.Date == DateTime.Now.Date;
        }
    }
}
