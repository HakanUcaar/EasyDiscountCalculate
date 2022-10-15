using EasyDiscountCalculate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Engine.Calculation.CalculateRules
{
    public class PercentRule : AbstractCalculateRule
    {
        private readonly Document _document;
        public PercentRule(Document document)
        {
            _document = document;
        }
        public static PercentRule New(Document document)
        {
            return new PercentRule(document);
        }

        protected override Calculation Calculate(Discount discount)
        {
            if (discount.DiscountValue > 100)
                return null;

            if(discount is null)
                return null;

            switch (discount.Domain)
            {
                case Common.Enums.DomainType.Document:
                    {
                        _document.Lines.ForEach(x => {
                            x.Discount = (discount.DiscountValue / 100);
                            x.Price = x.Price * (1 - x.Discount);
                         });
                    }
                    break;
                case Common.Enums.DomainType.DocumentLine:
                    {
                        var rawEffectedCount = Math.Truncate(_document.Lines.Sum(x => x.Quantity) / discount.TriggerValue);
                        var effectedCount = rawEffectedCount;

                        var list = new List<DocumentLine>();
                        _document.Lines.OrderBy(x => x.Price).ToList().ForEach(x =>
                        {
                            if(effectedCount > 0)
                            {
                                x.Discount = ((discount.DiscountValue / (x.Quantity > effectedCount ? x.Quantity : 1)) / 100);
                                x.Price = x.Price * (1 - x.Discount);

                                list.Add(x);
                                effectedCount -= x.Quantity;
                            }
                        });
                    }
                    break;
                default:
                    break;
            }

            return new Calculation(_document, discount, _document.DocTotal);
        }
    }
}
