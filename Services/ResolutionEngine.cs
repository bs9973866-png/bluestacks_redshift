namespace Redshift.Services;
public sealed class ResolutionEngine : IResolutionEngine {
    public ResolutionValidation Validate(int width,int height,int dpi,int fps,bool stretch){
        if(width<320||height<240)return new(false,"Resolution is below the safe minimum.");
        if(dpi<80||dpi>640)return new(false,"DPI must be between 80 and 640.");
        if(fps is not (30 or 60 or 90 or 120 or 144 or 165 or 240))return new(false,"FPS preset is unsupported.");
        var ratio=(double)width/height; if(stretch && Math.Abs(ratio-4.0/3)>0.03)return new(false,"Stretched 4:3 requires a 4:3 Android resolution.");
        return new(true,stretch?"Valid 4:3 profile; runtime support must be confirmed by BlueStacks.":"Valid Android resolution profile.");
    }
}
