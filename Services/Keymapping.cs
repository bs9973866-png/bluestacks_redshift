using System.IO;
using System.Text.Json;
namespace Redshift.Services;
public sealed record KeyBinding(string Action,string Key);
public sealed class KeymappingProfile { public string Name {get;set;}="Standoff 2"; public List<KeyBinding> Bindings {get;set;}=[new("Move forward","W"),new("Move left","A"),new("Move backward","S"),new("Move right","D"),new("Fire","Mouse1"),new("Jump","Space")]; }
public sealed class KeymappingStore {
 public async Task SaveAsync(KeymappingProfile profile,string path){Directory.CreateDirectory(Path.GetDirectoryName(path)!);await File.WriteAllTextAsync(path,JsonSerializer.Serialize(profile,new JsonSerializerOptions{WriteIndented=true}));}
 public async Task<KeymappingProfile?> LoadAsync(string path){if(!File.Exists(path))return null;try{return JsonSerializer.Deserialize<KeymappingProfile>(await File.ReadAllTextAsync(path));}catch{return null;}}
 public static bool Validate(KeymappingProfile p,out string error){var duplicate=p.Bindings.GroupBy(x=>x.Key,StringComparer.OrdinalIgnoreCase).FirstOrDefault(g=>g.Count()>1);error=duplicate==null?"Keymapping profile valid":$"Key '{duplicate.Key}' is assigned more than once";return duplicate==null&&p.Bindings.All(x=>!string.IsNullOrWhiteSpace(x.Action)&&!string.IsNullOrWhiteSpace(x.Key));}
}
