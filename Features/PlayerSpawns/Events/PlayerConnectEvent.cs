using AltV.Atlas.IoC.Attributes;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Atlas.Boilerplate.Features.PlayerSpawns.Events;

[Injectable(InstantiateOnBoot = true)]
public class PlayerConnectEvent
{
    private readonly PlayerSpawner _playerSpawner;

    public PlayerConnectEvent( PlayerSpawner playerSpawner )
    {
        _playerSpawner = playerSpawner;
        AltAsync.OnPlayerConnect += OnPlayerConnect;
    }

    private async Task OnPlayerConnect( IPlayer player, string reason )
    {
        Console.WriteLine( $"{ player.Name } Connected!" );
        
        await _playerSpawner.SpawnPlayerAsync( player );
    }
}