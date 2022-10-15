using EasyDiscountCalculate.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Common
{
    public class Document : IDocument
    {
        public DateTime DocDate { get; set; } = DateTime.Now;
        public double DocTotal { get { return Lines.Sum(x => x.LineTotal); } }
        public BusinessPartner BusinessPartner { get; set; } = new BusinessPartner();
        public List<DocumentLine> Lines { get; set; } = new List<DocumentLine>();
    }
}
