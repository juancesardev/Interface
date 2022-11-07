using FuncionesLinq.Data;
using Microsoft.EntityFrameworkCore;
using UniversidadInterfaces.Interfaces;
using UniversidadInterfaces.Servicios;

var builder = WebApplication.CreateBuilder(args);

// 2. conn sql
const string CONNECTIONNAME = "FuncLinq";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3. context
builder.Services.AddDbContext<FuncDBContext>(options => options.UseSqlServer(connectionString));
// Add services to the container.


//4.- add interfaces
builder.Services.AddTransient<Iestudios, estudios>();
// Add services to the container.
builder.Services.AddControllersWithViews();

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
