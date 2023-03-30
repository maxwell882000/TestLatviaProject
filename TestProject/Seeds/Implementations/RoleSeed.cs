using System;
using Microsoft.AspNetCore.Identity;
using TestProject.Domain.Users;

namespace TestProject.Seeds
{
    public class RoleSeed : IRoleSeed
    {
        IRoleRepository roleManager;
        public RoleSeed(IRoleRepository roleManager)
        {
            this.roleManager = roleManager;

        }

        public async Task seed()
        {
            this.roleManager.Add(new Role(RoleType.ADMIN.ToString()) { NormalizedName = RoleType.ADMIN.ToString() });
            this.roleManager.Add(new Role(RoleType.USER.ToString()) { NormalizedName = RoleType.USER.ToString() });
            this.roleManager.Commit();
        }
    }
}

