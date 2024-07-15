using Microsoft.AspNetCore.Authentication.JwtBearer;

using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    authenticationScheme: "OcelotAuthenticationScheme",
    configureOptions: (opt) =>
{
    opt.Authority = builder.Configuration["IdentityServerURL"];
    opt.RequireHttpsMetadata = false;
    opt.Audience = "ResourceOcelot";
});

IConfiguration ocelotConfiguration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json").Build();

builder.Services.AddOcelot(ocelotConfiguration);

var app = builder.Build();

await app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();
