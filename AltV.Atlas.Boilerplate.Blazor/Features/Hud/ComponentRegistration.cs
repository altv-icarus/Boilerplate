namespace AltV.Atlas.Boilerplate.Blazor.Features.Hud;

public static class ComponentRegistration
{
    public static void AddHud(this Dictionary<string, AtlasComponentBase> components)
    {
        components.Add("hud", new HudComponent());
    }
}