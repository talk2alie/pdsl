using Pdsl.Bff.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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
        policy.WithOrigins(frontEndBaseUri)
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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();
app.UseCors(pdslCorsPolicy);

app.Run();
