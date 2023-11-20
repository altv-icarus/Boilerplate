using AltV.Atlas.Boilerplate.Server.Features.Peds.Tasks;
using AltV.Atlas.Commands.Interfaces;
using AltV.Atlas.Peds.Factories;
using AltV.Atlas.Peds.Interfaces;
using AltV.Atlas.Peds.PedTasks;
using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Atlas.Boilerplate.Server.Features.Peds.Commands;

public class CreatePed : ICommand
{
    private readonly AtlasPedFactory _pedFactory;
    public string Name { get; set; } = "ped";
    public string[ ]? Aliases { get; set; } = new[ ] { "p" };
    public string Description { get; set; } = "Spawn a new ped at current location";
    public uint RequiredLevel { get; set; } = 0;

    public CreatePed( AtlasPedFactory pedFactory )
    {
        _pedFactory = pedFactory;
    }
    
    public async Task OnCommand( IPlayer player, string pedModel )
    {
        if( pedModel == "" )
            return;

        var ped = await _pedFactory.CreatePedAsync<IAtlasServerPed>( pedModel, player.Position, player.Rotation );
        // var task = new PedTaskWander( player.Position, 30, 5, 5 );
        var task = new PedTaskAttackPlayer( player.Id ); //, WeaponModel.SpecialCarbine );
        ped.SetPedTask( task );
    }
}