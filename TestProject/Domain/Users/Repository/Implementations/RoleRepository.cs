using System;
using TestProject.DatabaseContexts;
using TestProject.Domain.Common;

namespace TestProject.Domain.Users
{
    public class RoleRepository : GenericRepository<PostgresContext, Role>, IRoleRepository
    {
        public RoleRepository(PostgresContext context, ILogger<GenericRepository<PostgresContext, Role>> logger) : base(context, logger)
        {
        }
    }
}

