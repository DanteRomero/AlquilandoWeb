using AL.UI.Components;
//agregamos estas directivas using
using AL.Repositorios;
using AL.Aplicacion.CasosDeUso;
using AL.Aplicacion.Interfaces;
using AL.Aplicacion.Servicios;
using AL.Aplicacion.Validadores;

var builder = WebApplication.CreateBuilder(args);
EntidadesSqlite.Inicializar();

//agregamos estos servicios al contenedor DI

builder.Services.AddTransient<UsuarioAlta>();
builder.Services.AddTransient<AlojamientoAlta>();
builder.Services.AddTransient<BuscarAlojamientoCasoDeUso>();
builder.Services.AddScoped<AlojamientoEdicion>();
builder.Services.AddScoped<CancelarReservaCasoDeUso>();

builder.Services.AddSingleton<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddSingleton<ITarjetaRepositorio, TarjetaRepositorio>();
builder.Services.AddTransient<IAlojamientoRepositorio, AlojamientoRepositorio>();
builder.Services.AddTransient<IReservasRepositorio, ReservasRepositorio>();

builder.Services.AddTransient<IUsuarioValidador, UsuarioValidador>();
builder.Services.AddTransient<IAlojamientoValidador, AlojamientoValidador>();

builder.Services.AddTransient<IHashService, HashService>();
builder.Services.AddScoped<IServicioSesion, ServicioSesion>();
builder.Services.AddScoped<ServicioReserva>();

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
