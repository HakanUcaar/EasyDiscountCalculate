using EasyDiscountCalculate.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Common
{
    public class BusinessPartner : IBusinessPartner
    {
        public string Group { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
