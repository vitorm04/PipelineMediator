# PipelineMediator

Using IPipelineBehavior to generate requests and responses logs.


1 - Here, we are creating a pipeline behavior to log all requests and responses. 

```

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
    
 ```

2 - In the Startup.cs, we need to add the new pipeline behavior, with this line: 

```
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehaviour<,>));
```


You can define what kind of request or response it will log, using some interface or base class:

```
public class LoggingPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
                                                                where TRequest : ILogable
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
```

This way, only requests with `ILoggable` will be shown.
