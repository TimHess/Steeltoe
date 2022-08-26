// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.Configuration;
using Steeltoe.Common.Options;

namespace Steeltoe.Common.Test.Options;

internal sealed class TestOptions : AbstractOptions
{
    public string Foo { get; set; }

    public TestOptions(IConfiguration configuration, string sectionPrefix)
        : base(configuration, sectionPrefix)
    {
    }
}
