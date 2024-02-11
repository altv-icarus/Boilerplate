using AltV.Atlas.Boilerplate.Database.Features.Users.Models;
using AltV.Atlas.Boilerplate.Server.Features.Players.Interfaces;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Atlas.Boilerplate.Server.Features.Players.Entities;

public class AtlasPlayer : AsyncPlayer, IAtlasPlayer
{
    public AtlasPlayer( ICore core, IntPtr nativePointer, uint id ) : base( core, nativePointer, id )
    {
    }

    public User? User { get; set; }
}