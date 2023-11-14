using AltV.Atlas.Commands.Interfaces;

namespace AltV.Atlas.Boilerplate.Server.Features.Commands.Extensions;

public interface IExtendedCommand : ICommand
{
    string HelpText { get; set; }
}