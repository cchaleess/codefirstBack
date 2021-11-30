using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CodeFirst.HttpExceptions
{
    public class EnumExceptionsDescription
    {
        public string Value { get; private set; }

        public int CodeStatus { get; private set; }

        public static EnumExceptionsDescription InternalError { get { return new EnumExceptionsDescription("Internal Error service", (Int32)HttpStatusCode.InternalServerError); } }
        public static EnumExceptionsDescription Success { get { return new EnumExceptionsDescription("Success", (Int32)HttpStatusCode.OK); } }
        public static EnumExceptionsDescription Nofound { get { return new EnumExceptionsDescription("Not Found", (Int32)HttpStatusCode.NotFound); } }

        private EnumExceptionsDescription(string value , int codeStatus)         
        { 
            
            Value = value;
            CodeStatus = codeStatus;
        }
    }
}
