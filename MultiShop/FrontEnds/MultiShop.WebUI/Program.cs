using Microsoft.AspNetCore.Authentication.Cookies;

using MultiShop.WebUI.Services.Authentication.Handlers;
using MultiShop.WebUI.Services.Authentication.Models;
using MultiShop.WebUI.Services.Authentication.Services.Abstract;
using MultiShop.WebUI.Services.Authentication.Services.Concrete;
using MultiShop.WebUI.Services.ExternalApiServices.Basket.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Basket.Concrete;
using MultiShop.WebUI.Services.ExternalApiServices.Basket.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Concrete;
using MultiShop.WebUI.Services.ExternalApiServices.Comment.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Comment.Services.Concrete;
using MultiShop.WebUI.Services.ExternalApiServices.Discount.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Discount.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Discount.Services.Concrete;
using MultiShop.WebUI.Services.ExternalApiServices.Identity;
using MultiShop.WebUI.Services.ExternalApiServices.Order.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Order.Concrete;
using MultiShop.WebUI.Services.Ocelot.Models;

using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = "/auth/login";
    options.LogoutPath = "/auth/logout";
    options.AccessDeniedPath = "/auth/access-denied";
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    options.Cookie.Name = "MultiShopCookie";
});

builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IClientCredentialTokenService, ClientCredentialTokenService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

builder.Services.AddOptions<ClientSettings>().BindConfiguration(nameof(ClientSettings));
builder.Services.AddOptions<ServiceApiSettings>().BindConfiguration(nameof(ServiceApiSettings));

// Add services to the container.
var mvcBuilder = builder.Services.AddControllersWithViews();

if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}

var serviceApiSettings = builder.Configuration.GetSection(nameof(ServiceApiSettings)).Get<ServiceApiSettings>();

builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IIdentityService, IdentityService>();
builder.Services.AddHttpClient<IUserService, UserService>(opt =>
{
    opt.BaseAddress = new Uri(serviceApiSettings.IdentityApiUrl);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<ICustomerServiceService, CustomerServiceService>();

builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddScoped<IBasketService, BasketService>();

builder.Services.AddScoped<IDiscountService, DiscountService>();

builder.Services.AddScoped<IOrderAddressService, OrderAddressService>();

builder.Services.AddAccessTokenManagement();

var refitSettings = new RefitSettings
{
    ContentSerializer = new NewtonsoftJsonContentSerializer()
};

builder.Services.AddHttpClient("ClientCredentialCatalogApi", c =>
    c.BaseAddress = new Uri($"{serviceApiSettings.OcelotGatewayUrl}/{serviceApiSettings.Catalog.Path}"))
    .AddHttpMessageHandler<ClientCredentialTokenHandler>()
    .AddTypedClient(c => RestService.For<ICatalogApi>(c, refitSettings));

builder.Services.AddHttpClient("ResourceOwnerPasswordCatalogApi", c =>
    c.BaseAddress = new Uri($"{serviceApiSettings.OcelotGatewayUrl}/{serviceApiSettings.Catalog.Path}"))
    .AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>()
    .AddTypedClient(c => RestService.For<ICatalogApi>(c, refitSettings));

builder.Services.AddRefitClient<IBasketApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{serviceApiSettings.OcelotGatewayUrl}/{serviceApiSettings.Basket.Path}"))
    .AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddRefitClient<IOrderApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{serviceApiSettings.OcelotGatewayUrl}/{serviceApiSettings.Order.Path}"))
    .AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient("ClientCredentialCommentApi", c =>
    c.BaseAddress = new Uri($"{serviceApiSettings.OcelotGatewayUrl}/{serviceApiSettings.Comment.Path}"))
    .AddHttpMessageHandler<ClientCredentialTokenHandler>()
    .AddTypedClient(c => RestService.For<ICommentApi>(c, refitSettings));

builder.Services.AddHttpClient("ResourceOwnerPasswordCommentApi", c =>
    c.BaseAddress = new Uri($"{serviceApiSettings.OcelotGatewayUrl}/{serviceApiSettings.Comment.Path}"))
    .AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>()
    .AddTypedClient(c => RestService.For<ICommentApi>(c, refitSettings));

builder.Services.AddHttpClient("ClientCredentialDiscountApi", c =>
    c.BaseAddress = new Uri($"{serviceApiSettings.OcelotGatewayUrl}/{serviceApiSettings.Discount.Path}"))
    .AddHttpMessageHandler<ClientCredentialTokenHandler>()
    .AddTypedClient(c => RestService.For<IDiscountApi>(c, refitSettings));

builder.Services.AddHttpClient("ResourceOwnerPasswordDiscountApi", c =>
    c.BaseAddress = new Uri($"{serviceApiSettings.OcelotGatewayUrl}/{serviceApiSettings.Discount.Path}"))
    .AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>()
    .AddTypedClient(c => RestService.For<IDiscountApi>(c, refitSettings));

builder.Services.AddSingleton<IIdentityApi>((sp) =>
{
	IIdentityApi identityApi = RestService.For<IIdentityApi>(builder.Configuration["IdentityApiUrl"]);
	return identityApi;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
