

using System.Collections.Generic;

using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs.Player;

namespace DeathZoneDisablerinator3000;

public class Plugin : Plugin<DeathZoneConfig>
{
    public override string Name { get; } = "DeathZoneDisablerinator 3000";

    public override string Author { get; } = "Tiliboyy";
        
    public override void OnEnabled()
    {
        Exiled.Events.Handlers.Player.Hurting += OnHuring;

        base.OnEnabled();
    }
        

    private void OnHuring(HurtingEventArgs ev)
    {
        if (ev.IsInstantKill && ev.Player.CurrentRoom != null && ev.DamageHandler.Type == DamageType.Crushed && Config.Rooms.Contains(ev.Player.CurrentRoom.Type))
            ev.IsAllowed = false;
    }
}

public class DeathZoneConfig : IConfig
{
    public bool IsEnabled { get; set; } = true;

    public bool Debug { get; set; } = false;

    public List<RoomType> Rooms { get; set; } = new List<RoomType>()
    {
        RoomType.HczCrossRoomWater,
    };
}