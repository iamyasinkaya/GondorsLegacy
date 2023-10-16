using System.Reflection;
using Microsoft.AspNetCore.Routing;

namespace GondorsLegacy.Infrastructure.Web.MinimalApis;

public interface IEndpointHandler
{
    static abstract void MapEndpoint(IEndpointRouteBuilder builder);
}

public static class IEndpointRouteBuilderExtentions
{
    public static void MapEndpointHandlers(this IEndpointRouteBuilder builder, Assembly assembly)
    {
        var endpointHandlerTypes = assembly
            .GetTypes()
            .Where(x => x.GetInterfaces() != null && x.GetInterfaces().Contains(typeof(IEndpointHandler)))
            .ToList();

        foreach (var item in endpointHandlerTypes)
        {
            item.InvokeMember(nameof(IEndpointHandler.MapEndpoint), BindingFlags.InvokeMethod, null, null, new[] { builder });
        }
    }
}