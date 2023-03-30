using System;
using TestProject.DatabaseContexts;
using TestProject.Domain.Common;

namespace TestProject.Domain.Users
{
    public class UserRepository : GenericRepository<PostgresContext, User>, IUserRepository
    {
        public UserRepository(PostgresContext context, ILogger<GenericRepository<PostgresContext, User>> logger) : base(context, logger)
        {
        }
    }
}

