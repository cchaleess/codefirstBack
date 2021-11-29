using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.ValidationsAtributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class ValidationAttributeLengthGreaterthanFive : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;  
            result = ValidationLengthGreaterThanFive(value.ToString());

            return result;
        }

        // Checks if the entered phone number matches the mask.
        internal bool ValidationLengthGreaterThanFive(string atributeString)
        {
            if (atributeString.Length > 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }

    }
}
