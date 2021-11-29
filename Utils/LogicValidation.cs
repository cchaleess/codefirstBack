using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Utils
{
    public class LogicValidation
    {
        public bool ValidateIfDataIsNotNull (object parameterForController)
        {
            var isValid = parameterForController == null;

            return isValid;
        }
    }
}
