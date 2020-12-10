using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCShop.Web.Data
{
    using Entities;

    /// <summary>
    /// Alimentador semilla de base de datos, se encarga de llenar los registros base de la base de datos
    /// con el fin de no tener que estar intanciando o llenando registros manualmente cada que se borra la base de datos,
    /// ejemplo para datos genericos que no varian como por ejemplo Paises, Ciudades, Tipo Documentos
    /// Sexo, etc...
    /// </summary>
    public class SeedDb
    {
        private readonly DataContex contex;//Conexion db
        private Random random;

        public SeedDb(DataContex contex)
        {
            //Se carga la conexion a la base de datos por si solo, cada que algun metodo requiera DataContext el sistema llama el metodo Startup y pasa ese valor de la conexion
            this.contex = contex;
            this.random = new Random();
        }

        /// <summary>
        /// Metodo asincrono
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            //Espera a que la base de datos este creada, para esto es esta linea
            await this.contex.Database.EnsureCreatedAsync();

            //Evalua si la tabla contiene o no registros, si no contiene ingresa a el IF
            if (!this.contex.Products.Any())
            {
                //Si no se le han cargado registros a la tabla ingresa para cargarlos automaticamente
                this.AddProduct("Producto #1");
                this.AddProduct("Producto #2");
                this.AddProduct("Producto #3");
                await this.contex.SaveChangesAsync();//Almacena los cambios
            }
        }

        /// <summary>
        /// Crea producto en la base de datos
        /// </summary>
        /// <param name="Name"></param>
        private void AddProduct(string Name)
        {
            Product obj = new Product();

            obj.Name = Name;
            obj.Price = this.random.Next(100000);/*Asigna valor randon entre 0 y 100000*/
            obj.IsAvaliable = true;
            obj.Stock = this.random.Next(1000);/*Asigna valor randon entre 0 y 1000*/

            this.contex.Products.Add(obj);
        }

    }
}
