using System;
using System.Collections;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;

namespace BlockSCP.Handlers
{
    public class EventHandlers
    {
        private readonly Plugin<Config> plugin;

        public EventHandlers(Plugin<Config> plugin)
        {
            this.plugin = plugin;
        }

        public bool CommandLock = false;
        public Random rand = new Random();

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (plugin.Config.LockScpsAllRounds || CommandLock)
            {
                if (plugin.Config.Roles.Contains(ev.NewRole))
                {
                    ev.NewRole = plugin.Config.ReplaceRoles[rand.Next(0, plugin.Config.ReplaceRoles.Count)];
                }
            }
        }
    }
}
