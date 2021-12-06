using System.Collections.Generic;
using System.Linq;
using ApiExercicio3.Entities;
using ApiExercicio3.Produtos.Requests;
using ApiExercicio3.Produtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExercicio3.Produtos
{
    [ApiController]
    [Route("produtos")]
    public class ProdutosController : ControllerBase
    {
        private static readonly List<Produto> Produtos = new();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProdutoResponse>> Get()
        {
            return Ok(ProdutoResponse.Mapper(Produtos));
        }

        [HttpGet("{pId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProdutoResponse> Get(int pId)
        {
            var xPersistido = Produtos.FirstOrDefault(p => p.Id == pId);

            if (xPersistido == null)
                return NotFound();

            var xResponse = ProdutoResponse.Mapper(xPersistido);
            return Ok(xResponse);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProdutoResponse> Post([FromBody] ProdutoAdicionarRequests pRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var xItem = new Produto(pRequest.Nome, pRequest.Descricao, pRequest.Valor)
            {
                Id = Produtos.Count + 1
            };
            Produtos.Add(xItem);
            var xVariavel = ProdutoResponse.Mapper(xItem);
            return CreatedAtAction(nameof(Get), new { pId = xVariavel.Id }, xVariavel);
        }

        [HttpPut("{pId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProdutoResponse> Put(int pId, [FromBody] ProdutoAtualizarRequests pRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var xAtualiza = Produtos.FirstOrDefault(p => p.Id == pId);
            if (xAtualiza is null)
                return NotFound();

            xAtualiza.Nome = pRequest.Nome;
            xAtualiza.Descricao = pRequest.Descricao;
            xAtualiza.Valor = pRequest.Valor;
            return NoContent();
        }

        [HttpDelete("{pId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProdutoResponse> Delete(int pId)
        {
            var xDeleta = Produtos.FirstOrDefault(p => p.Id == pId);

            if (xDeleta is null)
                return NotFound();

            Produtos.Remove(xDeleta);
            return NoContent();
        }
    }
}