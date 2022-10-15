using EasyDiscountCalculate.Abstractions;
using EasyDiscountCalculate.Engine.Calculation.CalculateRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Common
{
    public class DocumentLine : IDocumentLine
    {
        public double Discount { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double LineTotal { get { return Price * Quantity; } }
        public Item Item { get; set; }

        public DocumentLine()
        {

        }

    }
}
