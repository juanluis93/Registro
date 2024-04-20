using Microsoft.EntityFrameworkCore;
using Registro.BLL.Contracts;
using Registro.BLL.Services;
using Registro.DAL.Context;
using Registro.DAL.Interfaces;
using Registro.DAL.Repositories;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IVisitante, VisitanteRepository>();
builder.Services.AddScoped<IUsuarios, UsuariosRepository>();
builder.Services.AddScoped<IEdificios, EdificioRepository>();
builder.Services.AddScoped<IAulas , AulaRepository>();

builder.Services.AddTransient<IVisitanteService, VisitanteService>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IEdificioService, EdificioService>();
builder.Services.AddTransient<IAulaService, AulaService>();



string conexion = builder.Configuration.GetConnectionString("VisitantesContext");
builder.Services.AddDbContext<VisitantesContext>(e => e.UseSqlServer(conexion));
var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.Run();
