using AltV.Atlas.Boilerplate.Database.Features.Users.Interfaces;
using AltV.Atlas.Boilerplate.Server.Features.Players.Entities;
using AltV.Atlas.Boilerplate.Server.Features.Players.Interfaces;
using AltV.Atlas.IoC.Attributes;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using Microsoft.Extensions.Logging;

namespace AltV.Atlas.Boilerplate.Server.Features.Users.Events;

[Injectable(InstantiateOnBoot = true)]
public class PlayerConnectAsyncEvent
{
    private readonly IUserService _userService;
    private readonly ILogger<PlayerConnectAsyncEvent> _logger;

    public PlayerConnectAsyncEvent( IUserService userService, ILogger<PlayerConnectAsyncEvent> logger )
    {
        _userService = userService;
        _logger = logger;

        AltAsync.OnPlayerConnect += OnPlayerConnectAsync;
    }

    private async Task OnPlayerConnectAsync( IPlayer player, string reason )
    {
        var atlasPlayer = ( IAtlasPlayer ) player;
        
        var user = await _userService.AuthenticateAsync( player.Name, "12345" );

        if( user is null )
        {
            _logger.LogInformation( "Unknown user {Name}, registering their account now...", player.Name );
            user = await _userService.RegisterAsync( player.Name, "12345", player.Ip );
        }
        
        _logger.LogInformation( "User registered/logged in!" );
        // assign user object to our atlas player for use later on
        atlasPlayer.User = user;
    }
}