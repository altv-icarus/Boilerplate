using AltV.Atlas.IoC.Attributes;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using Microsoft.Extensions.DependencyInjection;

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