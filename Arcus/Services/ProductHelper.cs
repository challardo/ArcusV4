using Arcus.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.Services
{
    public class ProductHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://arcus-cbaad.firebaseio.com/");

        public async Task<List<Producto>> GetAllProducts()
        {

            return (await firebase
              .Child("Products")
              .OnceAsync<Producto>()).Select(item => new Producto
              {
                  ProductoId = item.Object.ProductoId,
                  Nombre = item.Object.Nombre,
                  Categoria = item.Object.Categoria,
                  Descripcion = item.Object.Descripcion,
                  Cantidad = item.Object.Cantidad
                  
              }).ToList();
        }

        public async Task AddProducto(int productoid, string nombre, string categoria, string descripcion, int cantidad)
        {

            await firebase
              .Child("Products")
              .PostAsync(new Producto() {ProductoId=productoid,Nombre = nombre, Categoria = categoria, Descripcion = descripcion, Cantidad = cantidad});
        }

        public async Task<Producto> GetProducto(int productid)
        {
            var allProducts = await GetAllProducts();
            await firebase
              .Child("Products")
              .OnceAsync<Producto>();
            return allProducts.Where(a => a.ProductoId == productid).FirstOrDefault();
        }

        public async Task UpdateProduct(int productoid, string nombre, string categoria, string descripcion, int cantidad)
        {
            var toUpdatePerson = (await firebase
              .Child("Products")
              .OnceAsync<Producto>()).Where(a => a.Object.ProductoId == productoid).FirstOrDefault();

            await firebase
              .Child("Products")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Producto() { ProductoId = productoid, Nombre = nombre, Categoria = categoria, Descripcion = descripcion, Cantidad = cantidad });
        }

        public async Task DeleteProducto(int productId)
        {
            var toDeletePerson = (await firebase
              .Child("Products")
              .OnceAsync<Producto>()).Where(a => a.Object.ProductoId == productId).FirstOrDefault();
            await firebase.Child("Products").Child(toDeletePerson.Key).DeleteAsync();

        }

    }
}
