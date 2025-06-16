using System.Collections.Generic;
using System.Linq;

namespace ProductCatalog.Models
{
    public static class ProdutoManager
    {
        private static List<Produto> _produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Notebook", Preco = 3500.00m },
            new Produto { Id = 2, Nome = "Smartphone", Preco = 2000.00m },
            new Produto { Id = 3, Nome = "Tablet", Preco = 1500.00m }
        };

        public static List<Produto> ObterProdutos()
        {
            return _produtos;
        }

        public static void AdicionarProduto(Produto produto)
        {
            produto.Id = _produtos.Count > 0 ? _produtos.Max(p => p.Id) + 1 : 1;
            produto.DataCriacao = DateTime.Now;
            _produtos.Add(produto);
        }
    }
} 