using Microsoft.EntityFrameworkCore;
using Pdsl.Api.Data;
using Pdsl.Api.Licensing;
using Pdsl.Api.Mailing;

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

builder.Services.Configure<MailApiSettings>(builder.Configuration.GetSection(nameof(MailApiSettings)));
builder.Services.AddTransient<IMailingService, MailingService>();

// var pdslPolicy = "DefaultPDSLPolicy";
builder.Services.AddCors(options =>
{
    //var defaultOrigin = builder.Configuration.GetSection("DefaultClientOrigin").Value;
    //options.AddPolicy(name: pdslPolicy, policy =>
    //{
    //    policy.WithOrigins(defaultOrigin)
    //          .SetIsOriginAllowedToAllowWildcardSubdomains()
    //          .AllowAnyHeader()
    //          .AllowAnyMethod();
    //});
    options.AddDefaultPolicy(policy => 
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
