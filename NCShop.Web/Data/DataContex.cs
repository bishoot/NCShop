
using Microsoft.EntityFrameworkCore;
using NCShop.Web.Data.Entities;

namespace NCShop.Web.Data
{
    public class DataContex : DbContext
    {
        /* Se definen todas las entidades,  asi  public DbSet<Product> Products { get; set; }
         * Los nombres del objeto en singulas, los nombres del objecto en prurar*/
        public DbSet<Product> Products { get; set; }
        public DataContex(DbContextOptions<DataContex> options) : base(options)
        {
           
        }
    }
}
