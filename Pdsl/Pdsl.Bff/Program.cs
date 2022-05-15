using IdentityServer4.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Pdsl.Bff.Services;
using cookie = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults;
using oidc = Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = cookie.AuthenticationScheme;
    options.DefaultChallengeScheme = oidc.AuthenticationScheme;
})
.AddCookie(cookie.AuthenticationScheme)
.AddOpenIdConnect(oidc.AuthenticationScheme, options =>
{
    options.SignInScheme = cookie.AuthenticationScheme; ;
    options.Authority = "https://localhost:5001/";
    options.ClientId = "102b0e90-a929-4c55-b112-8541b5be76e4";
    options.ClientSecret = "3f8f6707-8a81-488d-92a3-a96205c6b754";
    options.ResponseType = "code";
    options.SaveTokens = true;
    options.GetClaimsFromUserInfoEndpoint = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var baseUrl = builder.Configuration.GetSection("PdslServiceBaseUrl").Value;
builder.Services.AddHttpClient<PdslService>(client => client.BaseAddress = new Uri(baseUrl));

var pdslCorsPolicy = "AllowFrontEndAngularApp";
builder.Services.AddCors(options => 
{
    var frontEndBaseUri = builder.Configuration.GetSection("PdslFrontEndAngularApp").Value;
    options.AddPolicy(pdslCorsPolicy, policy =>
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(pdslCorsPolicy);
app.UseHttpsRedirection();
app.UseStaticFiles();

// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
