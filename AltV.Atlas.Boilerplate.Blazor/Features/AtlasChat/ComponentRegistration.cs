namespace AltV.Atlas.Boilerplate.Blazor.Features.AtlasChat;

public static class ComponentRegistration
{
    public static void RegisterAtlasChat(this Dictionary<string, AtlasComponentBase> components)
    {
        components.Add("atlaschat", new AtlasChatBox());
    }
}