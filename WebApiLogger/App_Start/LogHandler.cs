using Serilog;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiLogger.App_Start
{
    public class LogHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Guid guid = Guid.NewGuid();

            //write request log
            Log.Information("{@Method}, {@RequestUri}, {@Content}, {@guid}", request.Method.Method, request.RequestUri, await request.Content.ReadAsStringAsync(), guid);

            // Call the inner handler.
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            //write response log
            Log.Information("{@guid}, {@StatusCode}, {@Content}", guid, response.StatusCode, await response.Content.ReadAsStringAsync());

            return response;
        }
    }
}