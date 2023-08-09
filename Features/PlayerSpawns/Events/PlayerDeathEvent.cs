﻿using AltV.Icarus.IoC.Attributes;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Icarus.Boilerplate.Features.PlayerSpawns.Events;

[Injectable(lifetime: ServiceLifetime.Singleton, InstantiateOnBoot = true)]
public class PlayerDeathEvent
{
    private readonly PlayerSpawner _playerSpawner;

    public PlayerDeathEvent( PlayerSpawner playerSpawner )
    {
        _playerSpawner = playerSpawner;
        AltAsync.OnPlayerDead += OnPlayerDead;
    }

    private Task OnPlayerDead( IPlayer player, IEntity killer, uint weapon )
    {
        return _playerSpawner.SpawnPlayerAsync( player );
    }
}