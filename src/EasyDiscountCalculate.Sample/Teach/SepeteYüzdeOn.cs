using EasyDiscountCalculate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Sample.Extend
{
    public class SepeteYüzdeOn : Discount
    {
        public SepeteYüzdeOn(Document document) : base(document)
        {
            DiscountValue = 10;
            Type = Common.Enums.DiscountType.Percent;
            Domain = Common.Enums.DomainType.Document;
        }
    }
}
