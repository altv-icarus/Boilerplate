using AltV.Atlas.Boilerplate.Server.Features.Vehicles.Overrides;
using AltV.Atlas.Commands.Interfaces;
using AltV.Atlas.Peds.Factories;
using AltV.Atlas.Peds.Interfaces;
using AltV.Atlas.Peds.PedTasks;
using AltV.Atlas.Peds.Shared.Factories;
using AltV.Net.Elements.Entities;
using AltV.Atlas.Vehicles.Server.Interfaces;

namespace AltV.Atlas.Boilerplate.Server.Features.Peds.Commands;

public class CreatePed( AtlasPedFactory pedFactory, PedTaskFactory pedTaskFactory ) : ICommand
{
    public string Name { get; set; } = "ped";
    public string[ ]? Aliases { get; set; } = new[ ] { "p" };
    public string Description { get; set; } = "Spawn a new ped at current location";
    public uint RequiredLevel { get; set; } = 0;

    public async Task OnCommand( IPlayer player, string pedModel, uint speed )
    {
        if( pedModel == "" )
            return;

        var ped = await pedFactory.CreatePedAsync<IAtlasServerPed>( pedModel, player.Position, player.Rotation );
        // var task = pedTaskFactory.CreatePedTask<PedTaskAttackPlayer>( player.Id, WeaponModel.SpecialCarbine );
        var task = pedTaskFactory.CreatePedTask<PedTaskWander>( player.Position, 30, 5, 5 );
        ped.SetPedTask( task );
    }
}