using LivroApi.DTO.Autor;
using LivroApi.Models;
using LivroApi.Services.Autor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _service;
        public AutorController(IAutorService service)
        {
            _service = service;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _service.ListarAutoresAsync();
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _service.BuscarAutorPorId(idAutor);
            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {
            var autor = await _service.BuscarAutorPorIdLivro(idLivro);
            return Ok(autor);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorDTO autor)
        {
            var autores = await _service.CriarAutor(autor);
            return Ok(autores);
        }

        [HttpDelete("ExcluirAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor(int idAutor)
        {
            var autores = await _service.ExcluirAutor(idAutor);
            return Ok(autores);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(AutorEdicaoDTO autor)
        {
            var autores = await _service.EditarAutor(autor);
            return Ok(autores);
        }
    }
}
