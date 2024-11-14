using LivroApi.DTO.Autor;
using LivroApi.Models;

namespace LivroApi.Services.Autor
{
    public interface IAutorService
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutoresAsync();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int id);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorDTO autorDTO);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDTO autorDTO);
    }
}
