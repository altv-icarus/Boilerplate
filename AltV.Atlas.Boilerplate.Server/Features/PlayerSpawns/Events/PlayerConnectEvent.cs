using AltV.Atlas.IoC.Attributes;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;

namespace AltV.Atlas.Boilerplate.Server.Features.PlayerSpawns.Events;

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