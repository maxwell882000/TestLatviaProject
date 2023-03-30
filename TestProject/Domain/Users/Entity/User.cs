using System;
using Microsoft.AspNetCore.Identity;

namespace TestProject.Domain.Users
{
    public class User : IdentityUser
    {
        public long Id { get; set; }

        public User()
        {
        }
    }
}

