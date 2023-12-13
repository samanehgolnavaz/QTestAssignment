using Microsoft.EntityFrameworkCore;
using QTest.Application.Interfaces;
using QTest.Application.Services;
using QTest.Infrastructure.Presistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QTestDbContext>(configure =>
{
    var constr = builder.Configuration.GetConnectionString("default");
    configure.UseSqlServer(connectionString: constr);
});

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
