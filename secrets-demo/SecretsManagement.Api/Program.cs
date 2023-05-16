using SecretsManagement.Api.AWS;
using SecretsManagement.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection(DatabaseSettings.SectionName)
);

builder.Services.Configure<MyCredentials>(builder.Configuration);

builder.Host.ConfigureAppConfiguration(((_, configurationBuilder) =>
{
    var config = builder.Configuration.GetSection(DatabaseSettings.SectionName).Get<DatabaseSettings>();
    configurationBuilder.AddAmazonSecretsManager(config?.Region ?? "ap-southeast-2", config?.SecretName ?? "mohrapi/mohrwebhost/appconfig");
}));

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();