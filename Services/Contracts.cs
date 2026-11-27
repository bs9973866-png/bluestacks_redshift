namespace Redshift.Services;
public interface IAdbClient { Task<AdbResult> ExecuteAsync(string arguments, CancellationToken cancellationToken=default); }
public sealed record AdbResult(bool Success, string Output, int ExitCode);
public interface IResolutionEngine { ResolutionValidation Validate(int width,int height,int dpi,int fps,bool stretch); }
public sealed record ResolutionValidation(bool Valid,string Message);
