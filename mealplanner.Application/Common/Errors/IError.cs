using System.Net;

namespace mealplanner.Application.Common.Errors
{
    public class Error : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
        public Error(HttpStatusCode statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    }
}
