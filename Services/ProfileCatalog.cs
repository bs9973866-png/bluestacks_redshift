using Redshift;
namespace Redshift.Services;
public sealed class ProfileCatalog {
 public IReadOnlyList<GameProfile> StandoffProfiles {get;}=[new("REDSHIFT EXTREME 4:3","4:3",1440,1080,240,144,true),new("REDSHIFT EXTREME 16:9","16:9",1920,1080,240,144,false),new("REDSHIFT COMPETITIVE","4:3",1280,960,220,120,true),new("REDSHIFT PERFORMANCE","16:9",1280,720,200,90,false),new("REDSHIFT LOW-END","16:9",1280,720,160,60,false),new("REDSHIFT BALANCED","16:9",1600,900,220,90,false)];
 public IEnumerable<(GameProfile Profile,string Result)> ValidateAll()=>StandoffProfiles.Select(p=>(p,BluestacksService.ValidateProfile(p)));
}
