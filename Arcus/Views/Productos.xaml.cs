using Arcus.Models;
using Arcus.Services;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Arcus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Productos : ContentPage
    {
        FirebaseClient firebase = new FirebaseClient("https://arcus-cbaad.firebaseio.com/");
        public Productos()
        {
            InitializeComponent();
        }
        FirebaseHelper FH = new FirebaseHelper();
        ProductHelper PH = new ProductHelper();
        protected async override void OnAppearing()
        {


            base.OnAppearing();
            var allProducts = await PH.GetAllProducts();
            lstProductos.ItemsSource = allProducts;

            var allPersons = await FH.GetAllPersons();
            //lstPersons.ItemsSource = allPersons;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await PH.AddProducto(Convert.ToInt32(ID.Text),Nombre.Text,Categoria.Text,Descripcion.Text, Convert.ToInt32(Cantidad.Text));

            //await FH.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text);
            ID.Text = string.Empty;
            Nombre.Text = string.Empty;
            Categoria.Text = string.Empty;
            Descripcion.Text = string.Empty;
            Cantidad.Text = string.Empty;

            await DisplayAlert("Success", "Product Added Successfully", "OK");
            var allProducts = await PH.GetAllProducts();
            lstProductos.ItemsSource = allProducts;
        }

        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            var product = await PH.GetProducto(Convert.ToInt32(ID.Text));
            if (product != null)
            {
                ID.Text = product.ProductoId.ToString();
                Nombre.Text = product.Nombre.ToString();
                Categoria.Text = product.Categoria.ToString();
                Descripcion.Text = product.Descripcion.ToString();
                Cantidad.Text = product.Cantidad.ToString();
               await DisplayAlert("Success", "Product Retrive Successfully", "OK");

            }
            else
            {
                await DisplayAlert("Success", "No Product Available", "OK");
            }

        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            await PH.UpdateProduct(Convert.ToInt32(ID.Text), Nombre.Text, Categoria.Text, Descripcion.Text, Convert.ToInt32(Cantidad.Text));
            ID.Text = string.Empty;
            Nombre.Text = string.Empty;
            Categoria.Text = string.Empty;
            Descripcion.Text = string.Empty;
            Cantidad.Text = string.Empty;
            await DisplayAlert("Success", "Product Updated Successfully", "OK");
            var allProducts = await PH.GetAllProducts();
            lstProductos.ItemsSource = allProducts;
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            await FH.DeletePerson(Convert.ToInt32(ID.Text));
            await DisplayAlert("Success", "Product Deleted Successfully", "OK");
            var allProducts = await PH.GetAllProducts();
            lstProductos.ItemsSource = allProducts;
        }

        async private void btnChart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Charts());
        }


        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            
            var mydetails = e.Item as Producto;
            //Nombre.Text = mydetails.ToString();
            await Navigation.PushAsync(new ProductosDescripcion(mydetails.ProductoId,mydetails.Nombre,mydetails.Categoria,mydetails.Descripcion,mydetails.Cantidad));
        }
    }
}