

using System.Collections.Generic;

using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs.Player;

namespace DeathZoneDisablerinator3000;

using System.ComponentModel;

public class Plugin : Plugin<DeathZoneConfig>
{
    public override string Name { get; } = "DeathZoneDisablerinator 3000";

    public override string Author { get; } = "Tiliboyy";
        
    public override void OnEnabled()
    {
        Exiled.Events.Handlers.Player.Hurting += OnHurting;

        base.OnEnabled();
    }
        

    private void OnHurting(HurtingEventArgs ev)
    {
        if (ev.IsInstantKill && ev.Player.CurrentRoom != null && ev.DamageHandler.Type == DamageType.Crushed && Config.DisabledRooms.Contains(ev.Player.CurrentRoom.Type))
        {
            ev.IsAllowed = false;
            ev.Player.DisableEffect(EffectType.PitDeath);
        }
    }
}

public class DeathZoneConfig : IConfig
{
    public bool IsEnabled { get; set; } = true;

    public bool Debug { get; set; } = false;

    [Description("The rooms where the deathzones are disabled")]
    public List<RoomType> DisabledRooms { get; set; } =
    [
        RoomType.HczCrossRoomWater,
    ];
}