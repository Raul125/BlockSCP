using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace BlockSCP
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class UnLockScps : ICommand
    {
        public string Command { get; } = "unlockscps";

        public string[] Aliases { get; } = { "ulscp", "ulscps" };

        public string Description { get; } = "UnLock Scps, only if you enabled it with the lock command";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get(sender as CommandSender);

            if (ply.CheckPermission("BSCP.unlock"))
            {
                BlockSCP.Singleton.EventHandlers.CommandLock = false;
                response = "<color=green>Done</color>";
                return true;
            }

            response = "<color=red>You don't have the requeried permissions</color>";
            return false;
        }
    }
}