using AltV.Atlas.Boilerplate.Server.Features.Players.Entities;
using AltV.Atlas.Boilerplate.Server.Features.Players.Interfaces;
using AltV.Net;
using AltV.Net.Elements.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Atlas.Boilerplate.Server.Features.Players.Factories;

public class AtlasPlayerFactory( IServiceProvider serviceProvider ) : IEntityFactory<IPlayer>
{
    public IPlayer Create( ICore core, IntPtr entityPointer, uint id )
    {
        return ActivatorUtilities.CreateInstance<AtlasPlayer>( serviceProvider, core, entityPointer, id );
    }
}