using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Engine.Validation
{
    public class ValidationFailure
    {
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }

        private ValidationFailure()
        {

        }
        public ValidationFailure(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}
