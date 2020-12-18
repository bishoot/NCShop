using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NCShop.Web.Controllers
{
    using Data.Entities;
    using Data.Repositories;
    using System.Threading.Tasks;

    public class ProductsController : Controller
    {
        private readonly IRepository repository;

        /*Este contructor inicializa con el repositorio que administra la base de datos segun la que se vaya a usar
         por medio de la interfaz del repositorio*/
        public ProductsController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(this.repository.GetProducts());
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.repository.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            {
                return View(product);
            }

        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        /* public IActionResult Create([Bind("Id,Name,Price,ImageUrl,LastPurchase,LastSale,IsAvaliable,Stock")] Product product)
         QUITAR EL BIND no sirve proboca errores posteriormente, cuando se actualiza el modelo tocaria definir los nuevos campos en el bind
        por eso es mejor quitarlo
        */
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)/*Valida las reglas del modelo*/
            {
                //Inserta el producto a la cola de cambios de la base de datos
                this.repository.AddProduct(product);
                //confirma todos los datos en la base de datos
                bool result= await this.repository.SaveAllAsync();
                if (result) { 
                    //Retorna a la vista Index
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Retorna a la vista para que se muestre los errores o definir que no se guardo
                    return View(product);
                }
            }

            //Retorna a la vista para que se muestre los errores
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.repository.GetProduct(id.Value);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return View(product);
            }
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult Edit(int id, [Bind("Id,Name,Price,ImageUrl,LastPurchase,LastSale,IsAvaliable,Stock")] Product product)
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.UpdateProduct(product);
                    await this.repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repository.ProductExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.repository.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = this.repository.GetProduct(id);
            if(product == null)
            {
                return NotFound();
            }

            this.repository.RemoveProduct(product);
            await this.repository.SaveAllAsync();
            return  RedirectToAction(nameof(Index));
        }

    }
}
