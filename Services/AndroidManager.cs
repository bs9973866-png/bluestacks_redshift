using System.IO;
namespace Redshift.Services;
public sealed class AndroidManager(IAdbClient adb) {
    public async Task<IReadOnlyList<string>> ListDevicesAsync(CancellationToken ct=default){var r=await adb.ExecuteAsync("devices",ct);if(!r.Success)return [];return r.Output.Split('\n',StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(x=>x.Trim().Split('\t')).Where(x=>x.Length>1&&x[1]=="device").Select(x=>x[0]).ToArray();}
    public async Task<AdbResult> ListPackagesAsync(CancellationToken ct=default)=>await adb.ExecuteAsync("shell pm list packages",ct);
    public async Task<AdbResult> InstallApkAsync(string apkPath,CancellationToken ct=default){if(!File.Exists(apkPath))return new(false,"APK file was not found.",-1);return await adb.ExecuteAsync($"install -r \"{apkPath.Replace("\"","\\\"")}\"",ct);}
    public async Task<AdbResult> UninstallAsync(string packageName,CancellationToken ct=default){if(string.IsNullOrWhiteSpace(packageName)||packageName.Any(c=>!(char.IsLetterOrDigit(c)||c=='.'||c=='_')))return new(false,"Invalid Android package name.",-1);return await adb.ExecuteAsync($"uninstall {packageName}",ct);}
    public async Task<AdbResult> RestartAndroidAsync(CancellationToken ct=default)=>await adb.ExecuteAsync("reboot",ct);
    public async Task<AdbResult> PushFileAsync(string localPath,string remotePath,CancellationToken ct=default){if(!File.Exists(localPath))return new(false,"Local file was not found.",-1);if(string.IsNullOrWhiteSpace(remotePath)||remotePath.Contains('"'))return new(false,"Invalid remote path.",-1);return await adb.ExecuteAsync($"push \"{localPath.Replace("\"","\\\"")}\" \"{remotePath}\"",ct);}
    public async Task<AdbResult> PullFileAsync(string remotePath,string localPath,CancellationToken ct=default){if(string.IsNullOrWhiteSpace(remotePath)||remotePath.Contains('"'))return new(false,"Invalid remote path.",-1);var folder=Path.GetDirectoryName(localPath);if(!string.IsNullOrWhiteSpace(folder))Directory.CreateDirectory(folder);return await adb.ExecuteAsync($"pull \"{remotePath}\" \"{localPath.Replace("\"","\\\"")}\"",ct);}
}
