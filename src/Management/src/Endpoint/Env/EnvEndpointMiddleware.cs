// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Steeltoe.Management.Endpoint.ContentNegotiation;
using Steeltoe.Management.Endpoint.Middleware;

namespace Steeltoe.Management.Endpoint.Env;

public class EnvEndpointMiddleware : EndpointMiddleware<EnvironmentDescriptor>
{
    private readonly RequestDelegate _next;

    public EnvEndpointMiddleware(RequestDelegate next, EnvEndpoint endpoint, IManagementOptions managementOptions, ILogger<EnvEndpointMiddleware> logger = null)
        : base(endpoint, managementOptions, logger)
    {
        _next = next;
    }

    public Task InvokeAsync(HttpContext context)
    {
        if (Endpoint.ShouldInvoke(managementOptions, logger))
        {
            return HandleEnvRequestAsync(context);
        }

        return Task.CompletedTask;
    }

    protected internal Task HandleEnvRequestAsync(HttpContext context)
    {
        string serialInfo = HandleRequest();
        logger?.LogDebug("Returning: {0}", serialInfo);

        context.HandleContentNegotiation(logger);
        return context.Response.WriteAsync(serialInfo);
    }
}
