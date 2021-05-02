using System.ComponentModel;
using Exiled.API.Interfaces;
using System.Collections.Generic;

namespace BlockSCP
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool LockScpsAllRounds { get; set; } = false;

        [Description("The list of the Scps that will be changed")]
        public List<RoleType> Roles { get; set; } = new List<RoleType>
        {
            RoleType.Scp049,
            RoleType.Scp079,
            RoleType.Scp096,
            RoleType.Scp106,
            RoleType.Scp173,
            RoleType.Scp93953,
            RoleType.Scp93989
        };

        [Description("The list of Roles to replace the scps")]
        public List<RoleType> ReplaceRoles { get; set; } = new List<RoleType>
        {
            RoleType.ClassD,
            RoleType.Scientist
        };
    }
}
