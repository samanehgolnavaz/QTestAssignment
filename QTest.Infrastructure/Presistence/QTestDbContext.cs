using Microsoft.EntityFrameworkCore;
using QTest.Domain.Entities;

namespace QTest.Infrastructure.Presistence;

public class QTestDbContext : DbContext
{

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer("data source=.;initial catalog=QTest.Database;TrustServerCertificate=True;Trusted_Connection=True;");
    }

    public QTestDbContext(DbContextOptions<QTestDbContext> dbContext)
        : base(dbContext)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>(x =>
        {

            x.HasKey(z => z.Id);

            x.Property(z => z.Name)
                .IsRequired()
                .HasMaxLength(100);

            x.Property(z => z.BirthOfDate)
                .IsRequired();

            x.Property(z => z.DepartmentId)
                .IsRequired();

            x.Property(z => z.Salary)
                .IsRequired();

            x.HasIndex(z => z.Name)
                .IsUnique();
        });

        modelBuilder.Entity<Department>(x =>
        {
            x.HasKey(z => z.Id);

            x.Property(z => z.Name)
                    .HasMaxLength(100)
                    .IsRequired();

            x.Property(z => z.HasPrinter)
                    .IsRequired();

            x.Property(z => z.Budget)
                    .IsRequired();

            x.HasMany(z => z.Employees)
                .WithOne(t => t.Department)
                .HasForeignKey(t => t.DepartmentId);

            x.HasIndex(z => z.Name)
                .IsUnique();
        });

    
    }
}
