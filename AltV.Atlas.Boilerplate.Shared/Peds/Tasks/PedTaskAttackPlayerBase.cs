using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Atlas.Shared.Attributes;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Atlas.Boilerplate.Shared.Peds.Tasks;

public class PedTaskAttackPlayerBase : IPedTask
{
    private const string Identifier = "96F55150-D79E-421E-B561-483A0186605F";
    
    [Identifier( Identifier )]
    public Guid Id { get; set; } = Guid.Parse( Identifier );

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

    public virtual void OnStop( )
    {
        throw new NotImplementedException( );
    }
}