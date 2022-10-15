using EasyDiscountCalculate.Abstractions;
using EasyDiscountCalculate.Common;
using EasyDiscountCalculate.Engine.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Engine.Calculation
{
    public class Calculation
    {
        public Discount Discount { get; set; }
        public Document Document { get; set; }
        public double DocTotal { get; set; }
        public List<ValidationFailure> Fails { get; set; }

        public Calculation()
        {

        }
        public Calculation(Document document = null,Discount discount = null,double docTotal = 0)
        {
            Document = document;
            Discount = discount;
            DocTotal = docTotal;
        }

    }
}
