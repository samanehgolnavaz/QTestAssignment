using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace QTest.Infrastructure.Presistence;

public class QTestDbContextFactory : IDesignTimeDbContextFactory<QTestDbContext>
{
    public QTestDbContext CreateDbContext(string[] args)
    {
        var connectionString = GetConnectionString();
        var assemblyName = typeof(QTestDbContextFactory).Assembly.GetName().ToString();

        var dbContextOptions = new DbContextOptionsBuilder<QTestDbContext>()
                                        .UseSqlServer(connectionString,
                                            configure =>
                                            {
                                                configure.MigrationsAssembly(assemblyName);
                                            })
                                        .Options;

        return new QTestDbContext(dbContextOptions);
    }

    private string GetConnectionString()
    {
        var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), ".."));
        var apiPath = Path.Combine(basePath, "QTest.API");

        var configuration = new ConfigurationBuilder()
                                    .SetBasePath(apiPath)
                                    .AddJsonFile("appsettings.Development.json")
                                    .Build();

        return configuration?.GetConnectionString("Default");
    }
}