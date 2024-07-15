using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

using MultiShop.Basket.Services.Abstract;
using MultiShop.Basket.Services.Concrete;
using MultiShop.Basket.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer((opt) =>
{
    opt.Authority = builder.Configuration["IdentityServerURL"];
    opt.RequireHttpsMetadata = false;
    opt.Audience = "ResourceBasket";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("BasketFullPermission", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c => c.Type == "scope" &&
            (c.Value == "BasketFullPermission")
            )));
});

builder.Services.AddOptions<RedisSettings>().BindConfiguration(nameof(RedisSettings));
builder.Services.AddSingleton(sp =>
{
    var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>();
    var redis = new RedisService(redisSettings);
    redis.Connect();
    return redis;
});

builder.Services.AddControllers();


builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
