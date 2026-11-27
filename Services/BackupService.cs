using System.IO;
using System.Text.Json;
namespace Redshift.Services;
public sealed class BackupService {
    public async Task<string> CreateAsync<T>(T value,string root){var folder=Path.Combine(root,"REDSHIFT-Backups",DateTime.Now.ToString("yyyyMMdd-HHmmss"));Directory.CreateDirectory(folder);await File.WriteAllTextAsync(Path.Combine(folder,"backup.json"),JsonSerializer.Serialize(value,new JsonSerializerOptions{WriteIndented=true}));return folder;}
}
