using Microsoft.Extensions.Options;
using StripeIntegrationDemo.Models;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure StripeSettings using values from appsettings.json
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configure Stripe secret key
Stripe.StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe")["SecretKey"];

app.Run();
