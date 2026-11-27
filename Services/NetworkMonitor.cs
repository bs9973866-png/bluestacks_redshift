using System.Net.NetworkInformation;
namespace Redshift.Services;
public sealed record NetworkSample(string Host,bool Reachable,long? LatencyMs,string Error);
public sealed class NetworkMonitor {
 public async Task<NetworkSample> PingAsync(string host="1.1.1.1",int timeout=1500){try{using var p=new Ping();var r=await p.SendPingAsync(host,timeout);return new(host,r.Status==IPStatus.Success,r.Status==IPStatus.Success?r.RoundtripTime:null,r.Status.ToString());}catch(Exception ex){return new(host,false,null,ex.Message);}}
 public async Task<IReadOnlyList<NetworkSample>> SampleAsync(IEnumerable<string> hosts){var results=new List<NetworkSample>();foreach(var h in hosts)results.Add(await PingAsync(h));return results;}
}
