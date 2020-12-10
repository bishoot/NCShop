using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;


namespace NCShop.Web
{
    using Data;//toma como base el directorio del NameSpace
    using Microsoft.AspNetCore;

    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();//Crea el servidor Web
            RunSeeding(host);/*Correr la semilla que carga los registros por defecto de la base de datos*/
            host.Run();/*Carga toda la información al servidor web*/
        }

        private static void RunSeeding(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<SeedDb>();//Carga el servicio de la clase SeedDb debido a que a este momento no se ha cargado todo el proyecto es la unica forma
                seeder.SeedAsync().Wait();//Se llama a el metodo de carga de registros por defecto
            }
        }

        /// <summary>
        /// Creacion del servidor web
        /// </summary>
        /// <param name="args">Argumentos base del metodo Main</param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                        .UseStartup<Startup>();
        }
         
    }
}