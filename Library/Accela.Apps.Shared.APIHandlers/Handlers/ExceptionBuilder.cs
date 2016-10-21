using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.WSModels;
using Accela.Apps.Shared.Exceptions;
using System;
using System.IdentityModel.Tokens;
using System.Net;
using System.Net.Http;

namespace Accela.Apps.Shared.APIHandlers
{
    public static class ExceptionBuilder
    {
        public static HttpResponseMessage BuildExceptionResponse(HttpRequestMessage request, Exception ex, string traceId)
        {
            return HttpResponseHelper.BuildErrorResponse(request, BuildErrorResponse(ex, traceId), traceId);
        }

        public static WSErrorResponse BuildErrorResponse(Exception ex, string traceId)
        {
            if (ex == null)
            {
                throw new Exception("invalid parameter ex. ex is null.");
            }

            var errorCode = (ex is MobileException) ? ((MobileException)ex).ErrorCode : null;
            var more = (ex is MobileException) ? ((MobileException)ex).Detail : null;

            WSErrorResponse error = new WSErrorResponse
            {
                TraceId = traceId,
                Message = ex.Message,
                More = more,
                Code = errorCode
            };

            if (ex is BadRequestException)
            {
                error.Status = (int)HttpStatusCode.BadRequest;

                if (String.IsNullOrWhiteSpace(error.Code))
                {
                    error.Code = ErrorCodes.invalid_uri_400;
                }
            }
            else if (ex is HasExistedException)
            {
                error.Status = (int)HttpStatusCode.BadRequest;

                if (String.IsNullOrWhiteSpace(error.Code))
                {
                    error.Code = ErrorCodes.record_has_existed_400;
                }
            }
            else if (ex is UnauthorizedException)
            {
                error.Status = (int)HttpStatusCode.Unauthorized;

                if (String.IsNullOrWhiteSpace(error.Code))
                {
                    error.Code = ErrorCodes.unauthorized_401;
                }
            }
            else if (ex is ForbiddenException)
            {
                error.Status = (int)HttpStatusCode.Forbidden;

                if (String.IsNullOrWhiteSpace(error.Code))
                {
                    error.Code = ErrorCodes.forbidden_403;
                }
            }
            else if (ex is NotFoundException)
            {
                error.Status = (int)HttpStatusCode.NotFound;

                if (String.IsNullOrWhiteSpace(error.Code))
                {
                    error.Code = ErrorCodes.not_found_404;
                }
            }
            else if (ex is MobileException)
            {
                if (Enum.IsDefined(typeof(HttpStatusCode), ((MobileException)ex).HttpStatus)) //Check if Mobile Exception error status is defined and valid.
                    error.Status = (int)((MobileException)ex).HttpStatus;
                else
                    error.Status = (int)HttpStatusCode.InternalServerError;

                /*
                 * This is a temporary solution.
                 * There is a kind of error, says EMSE Script error, which does not impact the process.
                 * The JSON response should indicate it via the code field.
                //*/

                if (String.IsNullOrWhiteSpace(error.Code))
                {
                    error.Code = ErrorCodes.internal_server_error_500;
                }
            }
            else if (ex is SecurityTokenException || ex is SecurityTokenValidationException)
            {
                error.Status = (int)HttpStatusCode.Unauthorized;
                if (String.IsNullOrWhiteSpace(error.Code))
                {
                    error.Code = ErrorCodes.unauthorized_401;
                }
            }
            else
            {
                error.Status = (int)HttpStatusCode.InternalServerError;
                error.Code = ErrorCodes.internal_server_error_500;
            }

            return error;
        }
    }
}
