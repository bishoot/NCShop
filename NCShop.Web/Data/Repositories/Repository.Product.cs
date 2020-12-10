
using System.Linq;

namespace NCShop.Web.Data.Repositories
{
    using Entities;
    using System.Collections.Generic;

    public partial class Repository
    {

        /// <summary>
        /// Crea un nuevo producto en la base de datos
        /// </summary>
        /// <param name="obj">objeto que se creara en la base de datos</param>
        public void AddProduct(Product obj)
        {
            this.contex.Products.Add(obj);
        }

        /// <summary>
        /// Actualiza el producto con la informacion del objeto
        /// </summary>
        /// <param name="obj">Objeto cargado con la llave e informacion que desea reemplazar</param>
        public void UpdateProduct(Product obj)
        {
            this.contex.Products.Update(obj);
        }

        /// <summary>
        /// Elimina el producto que corresponda a el objeto enviado
        /// </summary>
        /// <param name="obj">Producto que se desea eliminar</param> 
        public void RemoveProduct(Product obj)
        {
            this.contex.Products.Remove(obj);
        }

        /// <summary>
        /// Retorna todos los productos ordenados por el campo nombre
        /// </summary>
        /// <returns>Lista de productos</returns>
        public IEnumerable<Product> GetProducts()
        {
            return this.contex.Products.OrderBy(p => p.Name);
        }

        /// <summary>
        /// Retorna el producto que corresponde a el id
        /// </summary>
        /// <param name="id">Llave primaria del producto</param>
        /// <returns>Retorna producto correspondiente a la llave primaria</returns>
        public Product GetProduct(int id)
        {
            return this.contex.Products.Find(id);
        }

        /// <summary>
        /// Retorna true si existe un producto con esa llave primaria
        /// </summary>
        /// <param name="id">Llave primaria del producto</param>
        /// <returns>True si existe</returns>
        public bool ProductExists(int id)
        {
            return this.contex.Products.Any(p => p.Id == id);
        } 
    }
}
