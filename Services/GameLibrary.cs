namespace Redshift.Services;
public sealed record InstalledGame(string PackageName,bool Favorite=false);
public sealed class GameLibrary(IAdbClient adb) {
    public async Task<IReadOnlyList<InstalledGame>> DiscoverAsync(CancellationToken ct=default){var r=await adb.ExecuteAsync("shell pm list packages",ct);if(!r.Success)return [];return r.Output.Split('\n',StringSplitOptions.RemoveEmptyEntries).Where(x=>x.StartsWith("package:")).Select(x=>new InstalledGame(x[8..].Trim())).Where(x=>x.PackageName.Length>0).OrderBy(x=>x.PackageName).ToArray();}
    public Task<AdbResult> LaunchAsync(string packageName,CancellationToken ct=default){if(string.IsNullOrWhiteSpace(packageName)||packageName.Any(c=>!(char.IsLetterOrDigit(c)||c=='.'||c=='_')))return Task.FromResult(new AdbResult(false,"Invalid package name.",-1));return adb.ExecuteAsync($"shell monkey -p {packageName} 1",ct);}
}
