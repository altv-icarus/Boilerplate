using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Atlas.Boilerplate.Shared.Peds.Tasks;

public class PedTaskAttackPlayerBase : IPedTask
{
    public uint TargetId { get; set; }
    public uint WeaponHash { get; set; }

    public PedTaskAttackPlayerBase( uint targetId, uint weaponHash = 0 )
    {
        TargetId = targetId;
        WeaponHash = weaponHash;
    }

    public virtual void OnStart( ISharedPed ped )
    {
        throw new NotImplementedException( );
    }

    public virtual void OnStop( ISharedPed sharedPed )
    {
        throw new NotImplementedException( );
    }
}