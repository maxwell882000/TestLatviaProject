using System;
namespace TestProject.Domain.Common
{
	public interface IStamp
	{

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}

