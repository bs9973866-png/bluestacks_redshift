using System.Text;
namespace Redshift.Services;
public sealed class DiagnosticsService {
 public string CreateReport(string? blueStacksPath,string adbResult,bool adbOk){var root=Path.GetPathRoot(Environment.SystemDirectory)!;var sb=new StringBuilder();sb.AppendLine("REDSHIFT DIAGNOSTIC REPORT");sb.AppendLine($"Timestamp: {DateTimeOffset.Now:O}");sb.AppendLine($"OS: {Environment.OSVersion}");sb.AppendLine($"Architecture: {(Environment.Is64BitOperatingSystem?"x64":"x86")}");sb.AppendLine($"BlueStacks: {(string.IsNullOrWhiteSpace(blueStacksPath)?"not configured":blueStacksPath)}");sb.AppendLine($"ADB available: {adbOk}");sb.AppendLine(adbResult);sb.AppendLine($"Free disk GB: {new DriveInfo(root).AvailableFreeSpace/1024/1024/1024}");return sb.ToString();}
 public async Task<string> ExportAsync(string report,string folder){Directory.CreateDirectory(folder);var path=Path.Combine(folder,$"redshift-diagnostics-{DateTime.Now:yyyyMMdd-HHmmss}.txt");await File.WriteAllTextAsync(path,report);return path;}
}
