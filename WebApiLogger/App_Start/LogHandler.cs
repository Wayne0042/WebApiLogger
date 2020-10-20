using Serilog;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiLogger.App_Start
{
    public class LogHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //寫request log
            Log.Information("Process request");

            // Call the inner handler.
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            //寫response log
            Log.Information("Process response");

            return response;
        }
    }
}