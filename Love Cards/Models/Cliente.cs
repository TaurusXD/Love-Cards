using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Love_Cards.Models
{
    public class Cliente
    {
        private String nome { get; set; }
        private String telefone { get; set; }
        private String email { get; set; }
        private String senha { get; set; }
        private String cpf { get; set; }


        public Cliente(String nome, String telefone, String email, String senha, String cpf )
        {
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
            this.senha = senha;
            this.cpf = cpf;
        }

        public Cliente()
        {

        }

    }
}