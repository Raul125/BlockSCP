using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace BlockSCP
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class LockScps : ICommand
    {
        public string Command { get; } = "lockscps";

        public string[] Aliases { get; } = { "lscp", "lscps"};

        public string Description { get; } = "Lock Scps";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get(sender as CommandSender);

            if (ply.CheckPermission("BSCP.lock"))
            {
                BlockSCP.Singleton.EventHandlers.CommandLock = true;
                response = "<color=green>Done</color>";
                return true;
            }

            response = "<color=red>You don't have the requeried permissions</color>";
            return false;
        }
    }
}