using AL.UI.Components;
//agregamos estas directivas using
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using AL.Repositorios;
using AL.Aplicacion.CasosDeUso;
using AL.Aplicacion.Interfaces;
using AL.Aplicacion.Servicios;
using AL.Aplicacion.Validadores;
using AL.UI.Servicios;


var builder = WebApplication.CreateBuilder(args);
EntidadesSqlite.Inicializar();

//agregamos estos servicios al contenedor DI

builder.Services.AddTransient<UsuarioAlta>();
builder.Services.AddTransient<AlojamientoAlta>();
builder.Services.AddTransient<BuscarAlojamientoCasoDeUso>();
builder.Services.AddTransient<FiltrarAlojamientoCasoDeUso>();
builder.Services.AddTransient<AlojamientoEdicion>();
builder.Services.AddTransient<CancelarReservaCasoDeUso>();

builder.Services.AddSingleton<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ITarjetaRepositorio, TarjetaRepositorio>();
builder.Services.AddScoped<IAlojamientoRepositorio, AlojamientoRepositorio>();
builder.Services.AddScoped<IReservasRepositorio, ReservasRepositorio>();

builder.Services.AddTransient<IUsuarioValidador, UsuarioValidador>();
builder.Services.AddTransient<IAlojamientoValidador, AlojamientoValidador>();
builder.Services.AddTransient<IAlojamientoValidadorEdicion, AlojamientoValidadorEdicion>();

builder.Services.AddTransient<IHashService, HashService>();
builder.Services.AddScoped<IServicioSesion,ServicioSesion>();
builder.Services.AddScoped<IServicioReserva,ServicioReserva>();
builder.Services.AddScoped<ProtectedSessionStorage>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
