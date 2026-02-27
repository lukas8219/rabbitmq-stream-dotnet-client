// This source code is dual-licensed under the Apache License, version
// 2.0, and the Mozilla Public License, version 2.0.
// Copyright (c) 2017-2023 Broadcom. All Rights Reserved. The term "Broadcom" refers to Broadcom Inc. and/or its subsidiaries.

using System;
using System.Net;
using System.Threading.Tasks;

namespace RabbitMQ.Stream.Client;

public class AddressResolverDynamic : IAddressResolver
{
    private readonly Func<string, int, EndPoint> _resolveFunction;

    public AddressResolverDynamic(Func<string, int, EndPoint> resolveFunction)
    {
        _resolveFunction = resolveFunction;
        Enabled = true;
    }

    public bool Enabled { get; set; }
    [Obsolete("Deprecated. Use ResolveAsync instead.")]
    public EndPoint Resolve(string address, int port) => _resolveFunction(address, port);
#pragma warning disable CS0618
    public Task<EndPoint> ResolveAsync(string address, int port) => Task.FromResult(Resolve(address, port));
#pragma warning restore CS0618
}
