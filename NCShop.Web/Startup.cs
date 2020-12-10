using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NCShop.Web.Data;
namespace NCShop.Web
{
    using Data.Repositories;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*Crear el servicio que realiza la conexion a la base de datos, el nombre DefaultConnection
            pertenece a la conexion definida en el archivo appsettings.json, permite usar cualquier DB
            
             NOTA: esta linea lo que permite es decir que cualquier clase que en su conector llame un Datacontex automaticamente
            es cargado con esta conexion*/
            services.AddDbContext<DataContex>(cfg =>
            {
                cfg.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnectionSQLServer"));
            });

            /*Realiza la inyeccion del SeedDb para que la clase Program la pueda usar por medio de los scope*/
            services.AddTransient<SeedDb>();/*Dura mientras inicia la aplicacion y se destruye AddTransient, para larga duracion usar  services.AddScoped*/


            /*Instancia la interfas del repositorio cargado con la clase llamada del repositorio, se usa el metodo
             AddScoped porque esta persiste en la aplicacion a diferencia del AddTransient que dura mientras se inicia la aplicacion unicamente */
            services.AddScoped<IRepository, Repository>();



            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
