using System;

namespace ProductCatalog.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
} 