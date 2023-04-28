using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Authentication.Cookies;
using VistaBlazor;
using VistaBlazor.Interfaces;
using VistaBlazor.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Cadena de conexión
Config cadena = new Config(builder.Configuration.GetConnectionString("MySQL"));
builder.Services.AddSingleton(cadena);

builder.Services.AddScoped<ILoginServicio, LoginServicio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IServicioServicio, ServicioServicio>();
builder.Services.AddScoped<IFacturaServicio, FacturaServicio>();
builder.Services.AddScoped<IDetalleFacturaServicio, DetalleFacturaServicio>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddHttpContextAccessor();
builder.Services.AddResponseCompression();
builder.Services.AddControllers();
builder.Services.AddSweetAlert2();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseResponseCompression();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
