using System.Collections.Generic;
using System.Linq;
using ApiExercicio3.Entities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable MemberCanBePrivate.Global

namespace ApiExercicio3.Produtos.Responses
{
    public class ProdutoResponse
    {
        public string Descricao { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public static List<ProdutoResponse> Mapper(IEnumerable<Produto> pItens)
        {
            return pItens.Select(Mapper).ToList();
        }

        public static ProdutoResponse Mapper(Produto pItem)
        {
            return new ProdutoResponse
            {
                Id = pItem.Id,
                Descricao = pItem.Descricao,
                Valor = pItem.Valor,
                Nome = pItem.Nome
            };
        }
    }
}