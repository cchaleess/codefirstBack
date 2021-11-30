using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Interfaces
{
   public interface IValidationException
    {
        ContentResult Validate(string operation, object methodResponse, ContentResult content);
    }
}
