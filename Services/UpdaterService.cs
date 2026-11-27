using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
namespace Redshift.Services;
public sealed record UpdateManifest(string Version,string PackageUrl,string Sha256,string Notes);
public sealed class UpdaterService(HttpClient? client=null) {
 readonly HttpClient http=client??new HttpClient();
 public static bool IsHttps(string url)=>Uri.TryCreate(url,UriKind.Absolute,out var u)&&u.Scheme==Uri.UriSchemeHttps;
 public static bool IsNewer(string current,string candidate){return Version.TryParse(current,out var c)&&Version.TryParse(candidate,out var n)&&n>c;}
 public async Task<bool> VerifySha256Async(string file,string expected){using var stream=File.OpenRead(file);var hash=await SHA256.HashDataAsync(stream);return Convert.ToHexString(hash).Equals(expected.Trim(),StringComparison.OrdinalIgnoreCase);}
 public async Task<byte[]> DownloadAsync(string url,CancellationToken ct=default){if(!IsHttps(url))throw new InvalidOperationException("Updater accepts HTTPS URLs only.");return await http.GetByteArrayAsync(url,ct);}
}
