using CodeFirst.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CodeFirst.HttpExceptions
{
    public class ValidationException : IValidationException
    {
        public ValidationException()
        {
        }
        public ContentResult Validate(string operation, object methodResponse, ContentResult content)
        {
            string methodresponse = Convert.ToString(methodResponse);

            switch (operation)
            {
                case "PUT":
                case "DELETE":
                    //*fila no encontrada
                    if (methodresponse == EnumExceptionsDescription.Nofound.Value)
                    {
                        content.Content = EnumExceptionsDescription.Nofound.Value;
                        content.StatusCode = EnumExceptionsDescription.Nofound.CodeStatus;
                    }
                    else
                    {
                        //fallos de consulta
                        if (methodresponse == EnumExceptionsDescription.InternalError.Value)
                        {
                            content.Content = EnumExceptionsDescription.InternalError.Value;
                            content.StatusCode = EnumExceptionsDescription.InternalError.CodeStatus;
                        }
                        else
                        {
                            content.Content = EnumExceptionsDescription.Success.Value;
                            content.StatusCode = EnumExceptionsDescription.Success.CodeStatus;
                        }
                    }
                    break;
                case "POST":
                    //fallos de consulta
                    if (methodresponse != EnumExceptionsDescription.InternalError.Value)
                    {
                        content.Content = EnumExceptionsDescription.Success.Value;
                        content.ContentType = methodresponse;
                        content.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                    }
                    else
                    {
                        content.Content = EnumExceptionsDescription.InternalError.Value;
                        content.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                    }
                    break;
                case "GET":
                    //es correcto se ha obtenido los datos
                    if (methodresponse != EnumExceptionsDescription.InternalError.Value)
                    {
                        content.Content = methodresponse;
                        content.StatusCode = EnumExceptionsDescription.Success.CodeStatus;
                    }
                    else
                    {
                        content.Content = EnumExceptionsDescription.InternalError.Value;
                        content.StatusCode = EnumExceptionsDescription.InternalError.CodeStatus;
                    }
                    break;
            }
            return content;
        }
    }
}
