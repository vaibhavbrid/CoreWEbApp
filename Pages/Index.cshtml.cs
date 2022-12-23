using CoreWEbApp.Models;
using CoreWEbApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreWEbApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;

        public void OnGet()
        {
            ProductsService productsService = new();
            Products = productsService.GetProducts();
        }
    }
}