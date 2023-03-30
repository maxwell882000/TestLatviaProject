using System;
using Microsoft.AspNetCore.Identity;

namespace TestProject.Domain.Users
{

    public class Role : IdentityRole
    {
        public Role() { }
        public Role(string name) : base(name) { }
    }
}

