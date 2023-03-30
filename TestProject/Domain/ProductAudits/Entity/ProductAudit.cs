using System;
using TestProject.Domain.Common;

namespace TestProject.Domain.ProductAudits
{
    public class ProductAudit : IEntity, IStamp
    {

        public long Id { get; set; }


        public string? ChangedBy { get; set; }
        public string DataOld { get; set; }
        public string DateNew { get; set; }
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}

