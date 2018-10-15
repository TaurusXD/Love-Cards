using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Love_Cards.Models
{
    public class Produto
    {
        public String Nome { get; set; }
        public Decimal Preco { get; set; }
        public String imagem { get; set; }

        public Produto(String Nome, Decimal Preco, String imagem)
        {
            this.Nome = Nome;
            this.Preco = Preco;
            this.imagem = imagem;

        }

        public Produto()
        {

        }
    }
}