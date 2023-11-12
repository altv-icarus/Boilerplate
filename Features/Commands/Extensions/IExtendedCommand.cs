using AltV.Icarus.Commands.Interfaces;

namespace AltV.Icarus.Boilerplate.Features.Commands.Extensions;

public interface IExtendedCommand : ICommand
{
    string HelpText { get; set; }
}