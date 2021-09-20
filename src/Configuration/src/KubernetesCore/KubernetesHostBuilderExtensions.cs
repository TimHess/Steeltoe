﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.

using k8s;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Steeltoe.Common.Kubernetes;
using System;

namespace Steeltoe.Extensions.Configuration.Kubernetes
{
    public static class KubernetesHostBuilderExtensions
    {
        /// <summary>
        /// Add Kubernetes Configuration Providers for configmaps and secrets
        /// </summary>
        /// <param name="hostBuilder">Your HostBuilder</param>
        /// <param name="kubernetesClientConfiguration">Customize the <see cref="KubernetesClientConfiguration"/></param>
        /// <param name="loggerFactory"><see cref="ILoggerFactory"/></param>
        public static IWebHostBuilder AddKubernetesConfiguration(this IWebHostBuilder hostBuilder, Action<KubernetesClientConfiguration> kubernetesClientConfiguration = null, ILoggerFactory loggerFactory = null)
                => hostBuilder
                    .ConfigureAppConfiguration(cfg => cfg.AddKubernetes(kubernetesClientConfiguration, loggerFactory))
                    .ConfigureServices(svc => svc.AddKubernetesApplicationInstanceInfo().AddHostedService<KubernetesHostedService>());

        /// <summary>
        /// Add Kubernetes Configuration Providers for configmaps and secrets
        /// </summary>
        /// <param name="hostBuilder">Your WebHostBuilder</param>
        /// <param name="kubernetesClientConfiguration">Customize the <see cref="KubernetesClientConfiguration"/></param>
        /// <param name="loggerFactory"><see cref="ILoggerFactory"/></param>
        public static IHostBuilder AddKubernetesConfiguration(this IHostBuilder hostBuilder, Action<KubernetesClientConfiguration> kubernetesClientConfiguration = null, ILoggerFactory loggerFactory = null)
            => hostBuilder
                .ConfigureAppConfiguration(cfg => cfg.AddKubernetes(kubernetesClientConfiguration, loggerFactory))
                .ConfigureServices(svc => svc.AddKubernetesApplicationInstanceInfo().AddHostedService<KubernetesHostedService>());
    }
}
