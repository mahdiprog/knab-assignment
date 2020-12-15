using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Triskele.Config.Infra.Persistence
{
    class ConfigModelFactory: IDesignTimeDbContextFactory<ConfigModel>
    {
        public ConfigModel CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConfigModel>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Triskele.Config;Integrated Security=True;", x=>x.MigrationsHistoryTable("__EFMigrationsHistory", "cfg"));
            //optionsBuilder.UseMySql("server=localhost;database=Triskele_Config;user=root;password=master");

            return new ConfigModel(optionsBuilder.Options);
        }
    }
}

