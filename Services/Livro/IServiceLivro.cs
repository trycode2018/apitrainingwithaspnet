using LivroApi.DTO.Livro;
using LivroApi.Models;

namespace LivroApi.Services.Livro
{
    public interface IServiceLivro
    {
        Task<ResponseModel<List<LivroModel>>> ListLivroAsync();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int id);
        Task<ResponseModel<LivroModel>> BuscarLivroPorIdAutor(int id);
        Task<ResponseModel<List<LivroModel>>> AdicionarLivro(AdicionarDTO adicionarDTO);

    }
}
