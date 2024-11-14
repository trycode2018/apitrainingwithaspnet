using LivroApi.DTO.Livro;
using LivroApi.Models;
using LivroApi.Services.Livro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly IServiceLivro _livro;
        public LivroController(IServiceLivro livro) { this._livro = livro; }
        
        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var autor =  await _livro.BuscarLivroPorId(idLivro);
            return Ok(autor);
        }

        [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            var livro = await _livro.BuscarLivroPorIdAutor(idAutor);
            return Ok(livro);
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<List<ResponseModel<LivroModel>>>> ListarLivros()
        {
            var livros = await _livro.ListLivroAsync();
            return Ok(livros);
        }

        [HttpPost("AdicionarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> AdicionarLivro(AdicionarDTO add)
        {
            var livros = await _livro.AdicionarLivro(add);
            return Ok(livros);
        }
    }
}
