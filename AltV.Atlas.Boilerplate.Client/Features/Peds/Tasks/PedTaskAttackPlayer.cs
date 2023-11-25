using AltV.Atlas.Boilerplate.Shared.Peds.Tasks;
using AltV.Atlas.Peds.Client.Interfaces;
using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Net.Client;
using AltV.Net.Client.Async;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Atlas.Boilerplate.Client.Features.Peds.Tasks;

public class PedTaskAttackPlayer : PedTaskAttackPlayerBase
{
    private IAtlasClientPed _ped;
    private IPlayer? _target;
    private uint? _interval;

    public PedTaskAttackPlayer( uint targetId, uint weaponHash ) : base( targetId, weaponHash )
    {
    }
    
    public override void OnStart( ISharedPed ped )
    {
        if( ped is not IAtlasClientPed atlasClientPed || !ped.Exists )
            return;
        
        _target = Alt.GetAllPlayers( ).FirstOrDefault( p => p.RemoteId == TargetId );
        _ped = atlasClientPed;
        
        if( WeaponHash != 0 )
        {
            Alt.Natives.SetCanPedSelectAllWeapons( _ped.ScriptId, true );
            Alt.Natives.GiveWeaponToPed( _ped.ScriptId, WeaponHash, 9999, false, true );
            Alt.Natives.SetCurrentPedWeapon( _ped.ScriptId, WeaponHash, true );
        }

        _interval = Alt.SetInterval( On500ms, 500 );
    }

    private void On500ms( )
    {
        if( _target is null )
            return;
            
        Alt.Natives.ClearPedSecondaryTask( _ped.ScriptId );

        var dist = _ped.Position.Distance( _target.Position );
        var shouldShoot = dist is < 56 and > 48 or < 36 and > 28 or < 26 and > 18 or < 16 and > 8 or < 6;
        var hasLosToTarget = Alt.Natives.HasEntityClearLosToEntity( _ped.ScriptId, _target, 17 );
        var firingPattern = Alt.Hash( "FIRING_PATTERN_FULL_AUTO" );

        if( hasLosToTarget )
        {
            if( WeaponHash != 0 )
            {
                Alt.Natives.TaskShootAtEntity( _ped.ScriptId, _target, 5000, firingPattern );
            }
            else
            {
                Alt.Natives.TaskCombatPed( _ped.ScriptId, _target, 0, 16 );
            }
        }
        else if( dist is < 120 and > 5 )
        {
            Alt.Natives.TaskGoToEntityWhileAimingAtEntity( _ped.ScriptId, _target, _target, 1.7f, true, 0, 0, true, true, firingPattern );
        }
    }

    public override void OnStop( )
    {
        Alt.Natives.RemoveAllPedWeapons( _ped.ScriptId, true );

        if( _interval is not null )
        {
            Alt.ClearInterval( (uint) _interval );
            _interval = null;
        }
    }
}