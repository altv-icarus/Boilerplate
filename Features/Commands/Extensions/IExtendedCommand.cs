using AltV.Atlas.Commands.Interfaces;

namespace AltV.Atlas.Boilerplate.Features.Commands.Extensions;

public interface IExtendedCommand : ICommand
{
    string HelpText { get; set; }
}