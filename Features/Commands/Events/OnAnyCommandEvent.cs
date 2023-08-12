using AltV.Icarus.Commands;
using AltV.Icarus.IoC.Attributes;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AltV.Icarus.Boilerplate.Features.Commands.Events;

[Injectable(InstantiateOnBoot = true)]
public class OnAnyCommandEvent
{
    private readonly CommandManager _commandManager;
    private readonly ILogger<OnAnyCommandEvent> _logger;
    public OnAnyCommandEvent( CommandManager commandManager, ILogger<OnAnyCommandEvent> logger )
    {
        _commandManager = commandManager;
        _logger = logger;
        commandManager.OnAnyCommand += OnAnyCommand;
    }

    private void OnAnyCommand( IPlayer player, string[ ] arguments )
    {
        var command = arguments[ 0 ];

        if( !_commandManager.Exists( command ) )
        {
            player.Emit( "chat:message", null, $"Command \"{ command }\" does not exist." );
        }
        
        _logger.LogInformation( "{PlayerName} sent command: {Command} with arguments: {Arguments}", player.Name, arguments[ 0 ], arguments[1..] );
    }
}