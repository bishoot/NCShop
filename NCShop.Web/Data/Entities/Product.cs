using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NCShop.Web.Data.Entities
{
    
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /*DataNotations o Decoraciones,
         * DisplayFormatAttribute: cambia la visual del atribito en vista
         * DataFormatString:  el C2 indica 2 decimales y representacion simbolo de pesos y aplica separacion de mil como este configurado en el proyecto
         ApplyFormatInEditMode: Permite que no aparezca el formato cuando se este editando */
        [DisplayFormatAttribute(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(0, 999999999999999999.99)]/*Valida el rango de numero a ingresar*/
        [Column(TypeName = "decimal(18, 2)")]/*Adiciona la precision del campo, es obligatorio para los decimales*/
        public decimal Price { get; set; }
        /*
         * Display: cambia la visual del atributo en la vista
         * Name = "Imagen", adiciona el nombre que aparezca por defecto en la vista para el usuario final para que no use el nombre del atributo 
         */
        [Display(Name = "Imagen")]
        public string ImageUrl { get; set; }

        [Display(Name = "Última Compra")]
        public DateTime LastPurchase { get; set; }

        [Display(Name = "Última Venta")]
        public DateTime LastSale { get; set; }

        [Display(Name = "Disponible?")]
        public bool IsAvaliable { get; set; }
        /*DataNotations o Decoraciones,
         * DisplayFormatAttribute: cambia la visual del atribito en vista
         * DataFormatString:el N2 indica 2 decimales y aplica separacion de mil como este configurado en el proyecto
         ApplyFormatInEditMode: Permite que no aparezca el formato cuando se este editando */
        [DisplayFormatAttribute(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; } 
    }
}
