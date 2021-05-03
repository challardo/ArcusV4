using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Arcus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductosDescripcion : ContentPage
    {
        public ProductosDescripcion(int ProductoId, string Nombre, string Categoria, string Descripcion, int Cantidad)
        {
            InitializeComponent();
            ID.Text ="Product Id: " + ProductoId.ToString();
            NOMBRE.Text = "Product Name: " + Nombre;
            CATEGORIA.Text = "Product Category: " + Categoria;
            DESCRIPCION.Text = "Product Description: " + Descripcion;
            CANTIDAD.Text = "Product quantity: " + Cantidad.ToString();
        }
    }
}