
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCShop.Web.Data.Repositories
{
    using Entities;

    /*Esta clase permitira ejecutar y cambiar la base de datos por medio de una funcion propia de esta clase
     por defetco dar un clic para separar*/
    public interface IRepository
    {
        void AddProduct(Product obj);
        
        Product GetProduct(int id);
        
        IEnumerable<Product> GetProducts();
        
        bool ProductExists(int id);
        
        void RemoveProduct(Product obj);
        
        Task<bool> SaveAllAsync();
        
        void UpdateProduct(Product obj);
    }
}