using System.Diagnostics;
namespace Redshift.Services;
public sealed record BoosterReport(string Mode,long AvailableRamMb,int EmulatorProcesses,IReadOnlyList<string> Recommendations);
public sealed class SmartBooster {
 public BoosterReport Analyze(){var available=GC.GetGCMemoryInfo().TotalAvailableMemoryBytes/1024/1024;var ps=Process.GetProcessesByName("HD-Player");var tips=new List<string>();if(available<4096)tips.Add("Available memory is below 4 GB; close user-selected apps or reduce emulator RAM allocation.");else if(available<8192)tips.Add("Moderate memory headroom; use Balanced or Performance profile.");else tips.Add("Memory headroom is adequate for a standard gaming profile.");if(ps.Length>1)tips.Add($"{ps.Length} emulator processes detected; check instance memory use before starting more.");if(ps.Length==0)tips.Add("BlueStacks is not running; recommendations use host memory only.");tips.Add("No processes were stopped and no Windows security settings were changed.");return new(available<4096?"Low-End":available<8192?"Balanced":"Performance",available,ps.Length,tips);}
}
