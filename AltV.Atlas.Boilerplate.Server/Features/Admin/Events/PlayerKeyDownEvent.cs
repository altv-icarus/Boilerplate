// using AltV.Atlas.IoC.Attributes;
// using AltV.Atlas.KeyInputs.Server.Events;
// using AltV.Atlas.KeyInputs.Shared.Enums;
// using AltV.Net.Elements.Entities;
// namespace AltV.Atlas.Boilerplate.Server.Features.Admin.Events;
//
// [Injectable(InstantiateOnBoot = true)]
// public class PlayerKeyDownEvent
// {
//     private readonly AtlasKeyInputEvents _atlasKeyInputEvents;
//
//     public PlayerKeyDownEvent( AtlasKeyInputEvents atlasKeyInputEvents )
//     {
//         _atlasKeyInputEvents = atlasKeyInputEvents;
//         _atlasKeyInputEvents.OnPlayerKeyDown += OnPlayerKeyDown;
//     }
//
//     private void OnPlayerKeyDown( IPlayer player, AtlasKey key )
//     {
//         if( key != AtlasKey.F4 )
//             return;
//     }
// }