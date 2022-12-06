// Copyright 2022 De Staat der Nederlanden, Ministerie van Volksgezondheid, Welzijn en Sport.
// Licensed under the EUROPEAN UNION PUBLIC LICENCE v. 1.2
// SPDX-License-Identifier: EUPL-1.2

using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

bool EXPORT_PEM = true; 
bool EXPORT_DER = false; 
bool EXPORT_PER_COUNTRY = false;

var trustListFile = Environment.GetCommandLineArgs()[1];
var outputFolder = Environment.GetCommandLineArgs()[2];

Console.WriteLine($"Loading `{trustListFile}`");

var fileData = File.ReadAllText(trustListFile);
var data = JsonSerializer.Deserialize<IList<DccTrustListItem>>(fileData);

if (data == null)
{
    Console.WriteLine("No keys in the file");
    Environment.Exit(0);
}

Console.WriteLine($"There were {data.Count} certificates found, they will now be exported to {outputFolder}");

foreach (var item in data)
{
    var cert = new X509Certificate2(item.GetCertificateBytes());

    if (EXPORT_PER_COUNTRY) outputFolder = Path.Combine(outputFolder, item.Country ?? "xx");
    
    if (!Directory.Exists(outputFolder))
        Directory.CreateDirectory(outputFolder);
    
    var outputFile = Path.Combine(outputFolder, $"{WebUtility.UrlEncode(item.Kid)}.der");

    if (EXPORT_DER) File.WriteAllBytes(outputFile, item.GetCertificateBytes());
    if (EXPORT_PEM) File.WriteAllText(outputFile.Replace(".der", ".pem"), cert.ExportCertificatePem());
}

Console.WriteLine("Done!");