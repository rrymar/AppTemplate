using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.Errors;
using WebCore.WebClient;

namespace WebCore.Errors
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (DbUpdateConcurrencyException e)
            {
                context.Response.Headers.Add("Location", context.Request.Path.Value);
                HandleException(context, 307, e.Message);
            }
            catch (HttpStatusException e)
            {
                HandleException(context, (int)e.Status, e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                HandleException(context, 403, e.Message);
            }
            catch (AggregateException e)
            {
                HandleException(context, 500, e.InnerExceptions.Select(i => i.Message).ToArray());
            }
            catch (Exception e)
            {
                var innerUnauthorized = GetUnauthorizedAccessException(e);
                if (innerUnauthorized != null)
                {
                    HandleException(context, 403, e.Message);
                    return;
                }
                HandleException(context, 500, e.Message);
            }
        }

        private UnauthorizedAccessException GetUnauthorizedAccessException(Exception e)
        {
            if (e.InnerException is UnauthorizedAccessException innerUnauthorized)
                return innerUnauthorized;

            innerUnauthorized = e.InnerException?.InnerException as UnauthorizedAccessException;

            return innerUnauthorized ?? e.InnerException?.InnerException?.InnerException as UnauthorizedAccessException;
        }

        private static void HandleException(HttpContext context, int code, params string[] errors)
        {
            if (!context.Response.HasStarted)
            {
                var responseHeaders = new HeaderDictionary();
                foreach (var header in context.Response.Headers)
                    responseHeaders.Add(header);

                context.Response.Clear();

                foreach (var header in responseHeaders)
                    context.Response.Headers.Add(header);
            }

            WriteErrorResponse(context, code, errors);
        }

        private static void WriteErrorResponse(HttpContext context, int code, IEnumerable<string> errors)
        {
            var response = new ErrorResult(errors, context.TraceIdentifier);
            context.Response.StatusCode = code;
            context.Response.ContentType = "application/json";
            context.Response.WriteAsync(response.ToJson());
        }
    }
}
