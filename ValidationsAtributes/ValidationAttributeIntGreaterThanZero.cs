using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.ValidationsAtributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class ValidationAttributeIntGreaterThanZero : ValidationAttribute
    {
        // Internal field to hold the mask value.

        public override bool IsValid(object value)
        {
            bool result = true;
            var number = Convert.ToInt32(value);
           
            result = ValidateDataGreateThanZero(number);

            return result;
        }

        internal bool ValidateDataGreateThanZero(int Valuenumber)
        {
            if (Valuenumber > 0)
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
