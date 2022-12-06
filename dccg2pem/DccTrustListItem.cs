// Copyright 2022 De Staat der Nederlanden, Ministerie van Volksgezondheid, Welzijn en Sport.
// Licensed under the EUROPEAN UNION PUBLIC LICENCE v. 1.2
// SPDX-License-Identifier: EUPL-1.2

using System.Text.Json.Serialization;

public class DccTrustListItem
{
    [JsonPropertyName("kid")] public string? Kid { get; set; }
    [JsonPropertyName("timestamp")] public DateTime Timestamp { get; set; }
    [JsonPropertyName("country")] public string? Country { get; set; }
    [JsonPropertyName("certificateType")] public string? CertificateType { get; set; }
    [JsonPropertyName("thumbprint")] public string? Thumbprint { get; set; }
    [JsonPropertyName("signature")] public string? Signature { get; set; }
    [JsonPropertyName("rawData")] public string? RawData { get; set; }

    public byte[] GetCertificateBytes()
    {
        return Convert.FromBase64String(RawData ?? string.Empty);
    }
}
