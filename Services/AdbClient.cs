using System.Diagnostics;
namespace Redshift.Services;
public sealed class AdbClient(string? executable=null) : IAdbClient {
    readonly string command=string.IsNullOrWhiteSpace(executable)?"adb":executable;
    public async Task<AdbResult> ExecuteAsync(string arguments,CancellationToken cancellationToken=default){
        try { using var p=new Process{StartInfo=new ProcessStartInfo(command,arguments){UseShellExecute=false,CreateNoWindow=true,RedirectStandardOutput=true,RedirectStandardError=true}}; p.Start(); var outputTask=p.StandardOutput.ReadToEndAsync(cancellationToken);var errorTask=p.StandardError.ReadToEndAsync(cancellationToken);await p.WaitForExitAsync(cancellationToken);return new(p.ExitCode==0,await outputTask+await errorTask,p.ExitCode); }
        catch(Exception ex){return new(false,ex.Message,-1);}
    }
}
