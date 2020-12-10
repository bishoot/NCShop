

namespace NCShop.Web.Data.Repositories
{
    using System.Threading.Tasks;

    /*Se crea la clase Repository como partial, para que varias clases usen el mismo nombre de clase
     Esto permitira separar la logia en varios archivos haciendo referencia a la misma clase, por norma
    a los archivos que existenden de esta clase se les pone el nombre de la clase . nombre que de lo que hace*/
    public partial class Repository : IRepository
        /*IRepository es la interfaz clase que se crea por medio de clic derecho sobre la clase base, clic en la opcion
         * #1 llamada ACCIONES RAPIDAS Y REFACTORIZACIOENS, seguido dar clic en la opcion EXTRAER INTERFAZ, seguido de esto 
         * el visual creara la clase con el mismo nombre de esta anteponiendo una I, continuar el proceso dentro de esa clase
                                                  */
    {
        protected readonly DataContex contex;

        /// <summary>
        /// Constructor, carga la variable global para que quede con la conexion
        /// </summary>
        /// <param name="contex"></param>
        public Repository(DataContex contex)
        {
            this.contex = contex;
        }

        /// <summary>
        /// Almacena todos los cambios realizados en la transacción, metodo azincrono
        /// </summary>
        /// <returns>True si graba los cambios, false si no los graba</returns>
        public async Task<bool> SaveAllAsync()
        {
            /*await indica espere a que los grabe, grabara todos los registros modificados, insertados o borrados
             , retorna la cantidad de registros modificados si es mayor a 0 funciono de lo contrario false*/
            return await this.contex.SaveChangesAsync() > 0;
        }


    }
}
