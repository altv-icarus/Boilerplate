using AltV.Icarus.Chat;
using AltV.Icarus.Chat.Interfaces;
using AltV.Icarus.IoC.Attributes;
using AltV.Net.Elements.Entities;
using Microsoft.Extensions.Logging;

namespace AltV.Icarus.Boilerplate.Features.Chat.Events;

[Injectable(InstantiateOnBoot = true)]
public class OnChatMessageEvent
{
    private readonly IChat _chat;
    private readonly ILogger<OnChatMessageEvent> _logger;
    public OnChatMessageEvent( IChat chat, ILogger<OnChatMessageEvent> logger )
    {
        _chat = chat;
        _logger = logger;
        _chat.OnChatMessage += OnChatMessage;
    }

    private void OnChatMessage( IPlayer player, string message )
    {
        player.SendChatMessageToAll( message );
    }
}