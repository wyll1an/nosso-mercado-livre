using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace NossoMercadoLivreAPI.Service.Exceptions
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode statusCode = (context.Exception as WebException != null &&
                        ((HttpWebResponse)(context.Exception as WebException).Response) != null) ?
                         ((HttpWebResponse)(context.Exception as WebException).Response).StatusCode
                         : GetErrorCode(context.Exception.GetType());

            string errorMessage = context.Exception.Message;
            string stackTrace = context.Exception.StackTrace;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";
            var result = new ObjectResult(new
            {
                StatusCode = (int)statusCode,
                Message = errorMessage,
                StackTrace = stackTrace,
                IsError = true
            });

            context.Result = result;
        }

        private HttpStatusCode GetErrorCode(Type exceptionType)
        {
            if (Enum.TryParse<NossoMercadoLivreAPI.Domain.Enums.Exceptions>(exceptionType.Name, out Domain.Enums.Exceptions tryParseResult))
            {
                switch (tryParseResult)
                {
                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.NullReferenceException:
                        return HttpStatusCode.LengthRequired;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.FileNotFoundException:
                        return HttpStatusCode.NotFound;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.OverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.OutOfMemoryException:
                        return HttpStatusCode.ExpectationFailed;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.InvalidCastException:
                        return HttpStatusCode.PreconditionFailed;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.ObjectDisposedException:
                        return HttpStatusCode.Gone;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.UnauthorizedAccessException:
                        return HttpStatusCode.Unauthorized;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.NotImplementedException:
                        return HttpStatusCode.NotImplemented;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.NotSupportedException:
                        return HttpStatusCode.NotAcceptable;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.InvalidOperationException:
                        return HttpStatusCode.MethodNotAllowed;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.TimeoutException:
                        return HttpStatusCode.RequestTimeout;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.ArgumentException:
                        return HttpStatusCode.BadRequest;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.StackOverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.FormatException:
                        return HttpStatusCode.UnsupportedMediaType;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.IOException:
                        return HttpStatusCode.NotFound;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.IndexOutOfRangeException:
                        return HttpStatusCode.ExpectationFailed;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.ArgumentNullException:
                        return HttpStatusCode.NotFound;

                    case NossoMercadoLivreAPI.Domain.Enums.Exceptions.ForbiddenException:
                        return HttpStatusCode.Forbidden;

                    case Domain.Enums.Exceptions.AppException:
                    case Domain.Enums.Exceptions.SqlException:
                    case Domain.Enums.Exceptions.ValidationException:
                        return HttpStatusCode.InternalServerError;
                    
                    default:
                        return HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}