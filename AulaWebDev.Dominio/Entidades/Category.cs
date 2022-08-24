using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebDev.Dominio.Entidades
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public ICollection<Produto> Produtos { get; set; }

        public Category(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public Category(string descricao)
        {
            Descricao = descricao;
        }
    }
}
