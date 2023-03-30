using System;
using EntityFrameworkCore.Triggered;

namespace TestProject.Domain.Common
{
    public class TimestampTrigger : IBeforeSaveTrigger<IStamp>
    {
        public Task BeforeSave(ITriggerContext<IStamp> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added || context.ChangeType == ChangeType.Modified)
            {
                context.Entity.CreatedAt = DateTime.UtcNow;
            }
            if (context.ChangeType == ChangeType.Added)
            {
                context.Entity.UpdatedAt = DateTime.UtcNow;
            }
            return Task.CompletedTask;
        }
    }
}

