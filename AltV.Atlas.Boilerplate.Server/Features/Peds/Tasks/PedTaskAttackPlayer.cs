using AltV.Atlas.Boilerplate.Shared.Peds.Tasks;
using AltV.Net.Enums;

namespace AltV.Atlas.Boilerplate.Server.Features.Peds.Tasks;

public class PedTaskAttackPlayer : PedTaskAttackPlayerBase
{
    public PedTaskAttackPlayer( uint targetId, WeaponModel? weaponModel = null ) : base( targetId, weaponModel is null ? 0 : (uint) weaponModel )
    {
    }
}