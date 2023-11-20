using AltV.Atlas.Boilerplate.Shared.Peds.Tasks;
using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Net.Enums;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Atlas.Boilerplate.Server.Features.Peds.Tasks;

public class PedTaskAttackPlayer : PedTaskAttackPlayerBase
{
    public PedTaskAttackPlayer( uint targetId, WeaponModel? weaponModel = null ) : base( targetId, weaponModel is null ? 0 : (uint) weaponModel )
    {
    }
}