using Microsoft.EntityFrameworkCore;
using Pdsl.Api.Data;
using Pdsl.Api.Licensing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ITimedOneTimeAuthenticator, TimedOneTimeAuthenticator>();
builder.Services.AddTransient<IVisitorVerificationRepository, VisitorVerificationRepository>();

var connectionString = builder.Configuration.GetConnectionString("PdslDbContext");
builder.Services.AddDbContext<PdslDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
