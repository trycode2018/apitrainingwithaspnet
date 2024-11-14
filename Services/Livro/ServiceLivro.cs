using LivroApi.Data;
using LivroApi.DTO.Livro;
using LivroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivroApi.Services.Livro
{
    public class ServiceLivro : IServiceLivro
    {
        private readonly AppDbContext _context;
        public ServiceLivro(AppDbContext context) => _context = context;
        public async Task<ResponseModel<LivroModel>> BuscarLivroPorIdAutor(int id)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            var livro = await _context.Livros.Include(autor=>autor.Autor)
                .FirstOrDefaultAsync(Autor => Autor.Id == id);
            try
            {
                if(livro is null)
                {
                    resposta.Mensagem = "Nenhum registro de livro encontrado";
                    return resposta;
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Registro encontrado com sucesso ";
                resposta.Status = true;
                return resposta;
            }catch(Exception err)
            {
                resposta.Mensagem = err.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            var livro = await _context.Livros.FirstOrDefaultAsync(x => x.Id == idLivro);
            try
            {
                if (livro is null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livro localizado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = "Erro";
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListLivroAsync()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            var livros = await _context.Livros.Include(x=>x.Autor).ToListAsync();
            try
            {
                if (livros is null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado";
                    resposta.Status = true;
                    return resposta;
                }
                resposta.Dados = livros;
                resposta.Status = true;
                resposta.Mensagem = "Lista de livros registrados";
                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> AdicionarLivro(AdicionarDTO adicionarDTO)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            var livro = new LivroModel() { Titulo = adicionarDTO.Titulo };

            try
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Status = true;
                resposta.Mensagem = "Livro adicionado com sucesso ";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
