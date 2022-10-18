using EasyDiscountCalculate.Abstractions;
using EasyDiscountCalculate.Common.Enums;
using EasyDiscountCalculate.Engine.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Common
{
    public class Discount : DiscountValidator, IDiscount
    {
        public DiscountType Type { get; set; }
        public DomainType Domain { get; set; }
        public double DiscountValue { get; set; }
        public double TriggerValue { get; set; }
        public double EffectedValue { get; set; }

        public Discount(IDocument document) : base(document)
        {
        }

        public override ValidationResult Validate()
        {
            Fails.Clear();
            foreach (var item in Rules)
            {
                Fails.Add(item.Validate(this));
            }

            ValidationResult oValid = new ValidationResult(Fails);
            return oValid;
        }
    }
}
