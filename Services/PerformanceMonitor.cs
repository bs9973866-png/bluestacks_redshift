using System.Diagnostics;
namespace Redshift.Services;
public sealed record ProcessPerformance(int ProcessId,double CpuPercent,long RamMb);
public sealed class PerformanceMonitor {
 public async Task<IReadOnlyList<ProcessPerformance>> SampleBlueStacksAsync(int delayMs=500){var list=Process.GetProcessesByName("HD-Player").ToArray();var before=list.ToDictionary(p=>p.Id,p=>{try{return (p.TotalProcessorTime,DateTime.UtcNow);}catch{return (TimeSpan.Zero,DateTime.UtcNow);}});await Task.Delay(delayMs);var result=new List<ProcessPerformance>();foreach(var p in list){try{var b=before[p.Id];var cpu=(p.TotalProcessorTime-b.Item1).TotalMilliseconds/(DateTime.UtcNow-b.Item2).TotalMilliseconds/Environment.ProcessorCount*100;result.Add(new(p.Id,Math.Round(Math.Clamp(cpu,0,100),1),p.WorkingSet64/1024/1024));}catch{}}return result;}
}
