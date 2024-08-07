using Microsoft.AspNetCore.Authentication.JwtBearer;

using MultiShop.Catalog.Exceptions;
using MultiShop.Catalog.Services.Abstract;
using MultiShop.Catalog.Services.Concrete;
using MultiShop.Catalog.Settings;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<DatabaseSettings>().BindConfiguration(nameof(DatabaseSettings));

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<ICustomerServiceService, CustomerServiceService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer((opt) =>
{
    opt.Authority = builder.Configuration["IdentityServerURL"];
    opt.RequireHttpsMetadata = false;
    opt.Audience = "ResourceCatalog";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CatalogFullPermission", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c => c.Type == "scope" && c.Value == "CatalogFullPermission")));

    options.AddPolicy("CatalogReadPermission", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c => c.Type == "scope" && (c.Value == "CatalogFullPermission" || c.Value == "CatalogReadPermission"))));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
