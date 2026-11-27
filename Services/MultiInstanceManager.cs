using System.Diagnostics;
using System.IO;
namespace Redshift.Services;
public sealed record EmulatorInstance(string Name,string? Arguments,bool Running,int? ProcessId);
public sealed class MultiInstanceManager {
 public IReadOnlyList<EmulatorInstance> GetRunning(){return Process.GetProcessesByName("HD-Player").Select(p=>new EmulatorInstance("BlueStacks",null,true,p.Id)).ToArray();}
 public (bool ok,string message) Start(string executable,string? instanceName){if(!File.Exists(executable))return(false,"BlueStacks executable was not found.");if(!string.IsNullOrWhiteSpace(instanceName)&&instanceName.Any(c=>!(char.IsLetterOrDigit(c)||c is '_' or '-')))return(false,"Invalid instance name.");var args=string.IsNullOrWhiteSpace(instanceName)?string.Empty:$"--instance {instanceName}";try{var p=Process.Start(new ProcessStartInfo(executable,args){UseShellExecute=true});return(true,$"Launch requested (PID {p?.Id}). Instance argument support depends on this BlueStacks version.");}catch(Exception ex){return(false,ex.Message);}}
}
