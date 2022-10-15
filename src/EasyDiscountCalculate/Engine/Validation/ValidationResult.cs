using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiscountCalculate.Engine.Validation
{
    public class ValidationResult
    {
        private readonly List<ValidationFailure> errors;
        public virtual bool IsValid { get { return Errors.Count == 0; } }
        public List<ValidationFailure> Errors { get { return errors; } }
        public ValidationResult()
        {

        }
        public ValidationResult(List<ValidationFailure> failures)
        {
            errors = failures.Where(failure => failure != null).ToList();
        }
        public string ToString(string separator)
        {
            return string.Join(separator, errors.Select(failure => failure.ErrorMessage));
        }
        public override string ToString()
        {
            return ToString(Environment.NewLine);
        }
    }
}
