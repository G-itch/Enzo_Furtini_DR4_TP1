using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductCatalog.Models;

namespace ProductCatalog.Pages
{
    public class AdicionarProdutoModel : PageModel
    {
        [BindProperty]
        public Produto Produto { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Adiciona o produto usando o ProdutoManager
            ProdutoManager.AdicionarProduto(Produto);

            // Redireciona para a página inicial para ver o novo produto
            return RedirectToPage("/Index");
        }
    }
} 