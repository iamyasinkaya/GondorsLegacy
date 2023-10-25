using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace GondorsLegacy.Infrastructure.Interceptors;

public class LoggingInterceptor : IInterceptor
{
    private readonly ILogger<LoggingInterceptor> _logger;

    public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
    {
        _logger = logger;
    }

    public void Intercept(IInvocation invocation)
    {
        var methodName = invocation.Method.Name;
        var declaringType = invocation.TargetType;
        var arguments = string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()));
       

        var watch = System.Diagnostics.Stopwatch.StartNew();

        try
        {
            
            _logger.LogInformation($"Method {methodName} in class {declaringType} is about to be called with arguments: {arguments}");

            watch.Start();

            invocation.Proceed();

            watch.Stop();

            var returnValue = invocation.ReturnValue;
            _logger.LogInformation($"Method {methodName} in class {declaringType} was called successfully.");
            _logger.LogInformation($"Method {methodName} returned: {returnValue}");
            _logger.LogInformation($"Method {methodName} took {watch.ElapsedMilliseconds} ms to execute");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Method {methodName} in class {declaringType} threw an exception: {ex}");
            throw;
        }
    }



}