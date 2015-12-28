using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IManagerGenNHibernate.EN.IManager;

namespace MVCApp.Models {
    public class ProductoModels {
        [Display(Prompt = "Referencia", Description = "Referencia del producto", Name = "Referencia")]
        [Required(ErrorMessage = "Debe asignar una referencia al producto")]
        [Range(minimum: 0, maximum: Int32.MaxValue, ErrorMessage = "Debes introducir una referencia válida.")]
        public int Referencia { get; set; }

        [Display(Prompt = "Nombre", Description = "Nombre del producto", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Marca", Description = "Marca del producto", Name = "Marca")]
        [Required(ErrorMessage = "Debe indicar una marca para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "La marca no puede tener más de 200 caracteres")]
        public string Marca { get; set; }

        [Display(Prompt = "Precio de compra", Description = "Precio de compra del producto", Name = "Precio Compra")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        public float PrecioCompra { get; set; }

        [Display(Prompt = "Precio de venta", Description = "Precio de venta del producto", Name = "Precio Venta")]
        [Required(ErrorMessage = "Debe indicar un precio de venta para el producto")]
        public float PrecioVenta { get; set; }

        //[Display(Prompt = "Stock", Description = "Stock del producto", Name = "Stock")]
        //[Required(ErrorMessage = "Debe indicar un stock para el producto")]
        public int Stock { get; set; }

        //[Required(ErrorMessage = "Debe indicar un proveedor para el producto")]
        [Display(Name="Proveedores")]
        public IEnumerable<ProveedorModels> proveedor { get; set; }

        //public IList<string> proovedoresStrings { get; set; }
        //public string[] selectedProveedores { get; set; }
        public IEnumerable<string> SelectedItems { get; set; }

        [Display(Name = "Productos")]
        public IEnumerable<ProductoEN> productos { get; set; }

        //public IList<string> proovedoresStrings { get; set; }
        //public string[] selectedProveedores { get; set; }
        public IEnumerable<string> SelectedProducto { get; set; }
    }
}