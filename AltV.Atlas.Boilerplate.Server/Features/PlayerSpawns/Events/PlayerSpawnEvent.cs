using AltV.Atlas.IoC.Attributes;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;

namespace AltV.Atlas.Boilerplate.Server.Features.PlayerSpawns.Events;

[Injectable(InstantiateOnBoot = true)]
public class PlayerSpawnEvent
{
    private readonly PlayerSpawner _playerSpawner;

    public PlayerSpawnEvent( PlayerSpawner playerSpawner )
    {
        _playerSpawner = playerSpawner;
        AltAsync.OnPlayerSpawn += OnPlayerSpawn;
    }

    private async Task OnPlayerSpawn( IPlayer player )
    {
    }
}