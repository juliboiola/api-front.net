using crudapi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // inicializa 
//configurar services(dependencias, db connection,controladores)

// Add services to the container.
builder.Services.AddControllersWithViews(); // agrega controladores y vistas

builder.Services.AddDbContext<AppDBContext>(options =>                              //configura dbcontext
   {
       options.UseSqlServer(builder.Configuration.GetConnectionString("StringSQL"));  // indica uso de sqlserver, string de conexion en appsettjson
   });


var app = builder.Build();   //construye app

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())          //pasos de c-request cuando entra al server
{
    app.UseExceptionHandler("/Home/Error");   // si no esta en modo dev cualq error redirige a vista home/err 
}
app.UseStaticFiles();                        // permite archivos staticos -css js img- desde wwwroot

app.UseRouting();                            //decide q controlador/acción responde a cada request

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",        
    pattern: "{controller=Empleado}/{action=Lista}/{id?}");      // rutas por default

app.Run();
