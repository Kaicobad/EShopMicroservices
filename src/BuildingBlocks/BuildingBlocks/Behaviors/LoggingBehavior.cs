using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest,TResponse>> _logger) 
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("[SART] Handle request = {Request} - response = {Response} - requestData = {RequestData}",
                typeof(TRequest).Name, request, typeof(TResponse).Name, request);
            
            var timer = new Stopwatch();
            timer.Start();

            var response = await next();
            timer.Stop();

            var timeTaken = timer.Elapsed;
            if (timeTaken.Seconds > 3)
            {
               _logger.LogWarning("[PERFORMANCE] The request {Request} took {TimeTaken}", typeof(TRequest).Name, timeTaken.Seconds);
            }
            _logger.LogInformation("[END] Handle {Request} With {Response}", typeof(TRequest).Name, typeof(TResponse).Name);
            return response;

        }
    }
}
