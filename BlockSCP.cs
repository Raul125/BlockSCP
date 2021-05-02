using System;
using Exiled.API.Features;
using Exiled.API.Enums;
using BlockSCP.Handlers;

namespace BlockSCP
{
    public class BlockSCP : Plugin<Config>
    {
        public EventHandlers EventHandlers;
        public override Version RequiredExiledVersion { get; } = new Version("2.10.0");
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public override string Author { get; } = "Raul125";
        public override string Name { get; } = "BlockSCP";
        public override Version Version { get; } = new Version("1.0.0");
        public static BlockSCP Singleton;

        public override void OnEnabled()
        {
            Singleton = this;
            EventHandlers = new EventHandlers(this);
            Exiled.Events.Handlers.Player.ChangingRole += EventHandlers.OnChangingRole;
            Exiled.Events.Handlers.Server.RestartingRound += EventHandlers.OnRoundRestarting;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.ChangingRole -= EventHandlers.OnChangingRole;
            Exiled.Events.Handlers.Server.RestartingRound -= EventHandlers.OnRoundRestarting;
            EventHandlers = null;
            Singleton = null;
            base.OnDisabled();
        }
    }
}
