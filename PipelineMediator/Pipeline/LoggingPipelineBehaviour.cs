using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace PipelineMediator.Pipeline
{
    public class LoggingPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
                                                                where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> _logger;

        public LoggingPipelineBehaviour(ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("Request - {@request}", request);
            var response = await next();
            _logger.LogInformation("Response - {@response}", response);
            return response;
        }
    }
}
