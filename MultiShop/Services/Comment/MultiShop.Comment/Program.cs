using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

using MultiShop.Comment.Context;

using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer((opt) =>
        {
            opt.Authority = builder.Configuration["IdentityServerURL"];
            opt.RequireHttpsMetadata = false;
            opt.Audience = "ResourceComment";
        });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("CommentReadPermission", policy =>
                policy.RequireAssertion(context =>
                    context.User.HasClaim(c => c.Type == "scope" && (c.Value == "CommentReadPermission" || c.Value == "CommentFullPermission"))));

            options.AddPolicy("CommentFullPermission", policy =>
                policy.RequireAssertion(context =>
                    context.User.HasClaim(c => c.Type == "scope" &&
                    (c.Value == "CommentFullPermission")
                    )));
        });


        builder.Services.AddDbContext<CommentContext>(optionsBuilder =>
        {
            optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
        });

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
    }
}