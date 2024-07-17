using Microsoft.Extensions.Options;
using StripeIntegrationDemo.Models; // Asegúrate de agregar esta línea
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar StripeSettings usando los valores de appsettings.json
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

// Construir la aplicación
var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configurar la clave secreta de Stripe
Stripe.StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe")["SecretKey"];

app.Run();