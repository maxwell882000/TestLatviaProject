using System;
namespace TestProject.Seeds
{
    public class MainSeed : IMainSeed
    {
        IProductSeed productSeed;
        ILogger<MainSeed> logger;
        IRoleSeed roleSeed;
        IUserAdminSeed userAdmin;
        public MainSeed(IProductSeed productSeed,
            IRoleSeed roleSeed,
            IUserAdminSeed userAdmin,
         ILogger<MainSeed> logger)
        {
            this.roleSeed = roleSeed;
            this.productSeed = productSeed;
            this.userAdmin = userAdmin;
            this.logger = logger;
        }

        public async Task seed()
        {
            this.logger.LogWarning("Started SEED PROCESS");
            // this.productSeed.seed();
            // this.roleSeed.seed();
            await this.userAdmin.seed();
            this.logger.LogWarning("ENDED SEED PROCESS");
        }
    }
}

