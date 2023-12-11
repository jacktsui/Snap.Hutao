﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Extensions.Options;
using Snap.Hutao.Web.Hoyolab.DataSigning;
using System.Collections.Frozen;

namespace Snap.Hutao.Web.Hoyolab;

/// <summary>
/// 米游社选项
/// </summary>
internal sealed class HoyolabOptions : IOptions<HoyolabOptions>
{
    /// <summary>
    /// 米游社请求UA
    /// </summary>
    public const string UserAgent = $"Mozilla/5.0 (Windows NT 10.0; Win64; x64) miHoYoBBS/{SaltConstants.CNVersion}";

    /// <summary>
    /// Hoyolab 请求UA
    /// </summary>
    public const string UserAgentOversea = $"Mozilla/5.0 (Windows NT 10.0; Win64; x64) miHoYoBBSOversea/{SaltConstants.OSVersion}";

    /// <summary>
    /// 米游社移动端请求UA
    /// </summary>
    public const string MobileUserAgent = $"Mozilla/5.0 (Linux; Android 12) Mobile miHoYoBBS/{SaltConstants.CNVersion}";

    /// <summary>
    /// Hoyolab 移动端请求UA
    /// </summary>
    public const string MobileUserAgentOversea = $"Mozilla/5.0 (Linux; Android 12) Mobile miHoYoBBSOversea/{SaltConstants.OSVersion}";

    /// <summary>
    /// 米游社设备Id
    /// </summary>
    public static string DeviceId { get; } = Guid.NewGuid().ToString();

    /// <summary>
    /// 扫码登录设备Id
    /// </summary>
    public static string Device { get; } = Core.Random.GetLetterAndNumberString(64);

    /// <summary>
    /// 盐
    /// </summary>
    public static FrozenDictionary<SaltType, string> Salts { get; } = new Dictionary<SaltType, string>()
    {
        // Chinese
        [SaltType.K2] = SaltConstants.CNK2,
        [SaltType.LK2] = SaltConstants.CNLK2,
        [SaltType.X4] = "xV8v4Qu54lUKrEYFZkJhB8cuOh9Asafs",
        [SaltType.X6] = "t0qEgfub6cvueAPgR5m9aQWWVciEer7v",
        [SaltType.PROD] = "JwYDpKvLj6MrMqqYU6jTKF17KNO2PXoS",

        // Oversea
        [SaltType.OSK2] = SaltConstants.OSK2,
        [SaltType.OSLK2] = SaltConstants.OSLK2,
        [SaltType.OSX4] = "h4c1d6ywfq5bsbnbhm1bzq7bxzzv6srt",
        [SaltType.OSX6] = "okr4obncj8bw5a65hbnn5oo6ixjc3l9w",
    }.ToFrozenDictionary();

    /// <inheritdoc/>
    public HoyolabOptions Value { get => this; }
}