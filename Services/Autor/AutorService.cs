using LivroApi.Data;
using LivroApi.DTO.Autor;
using LivroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivroApi.Services.Autor
{
    public class AutorService : IAutorService
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context) => _context = context;

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int id)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id);
                if(autor is null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "Autor localizado";
                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var livro = await _context.Livros.Include(x=>x.Autor).
                    FirstOrDefaultAsync(livro=>livro.Id == idLivro);

                if(livro is null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado";
                    resposta.Status = false;
                    return resposta;
                }

                resposta.Dados = livro.Autor!;
                resposta.Mensagem = "Autor localizado pelo seu livro";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorDTO autorDTO)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = new AutorModel() { Nome = autorDTO.Nome, Sobrenome = autorDTO.Sobrenome };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                
                resposta.Status = true;
                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor criado com sucesso";

                return resposta;

            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDTO autorDTO)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x=>x.Id==autorDTO.Id);

                if(autor == null)
                {
                    resposta.Mensagem = "Nenhum autor encontrado";
                    return resposta;
                }
                autor.Nome = autorDTO.Nome;
                autor.Sobrenome = autorDTO.Sobrenome;
                _context.Update(autor);

                await _context.SaveChangesAsync();


                resposta.Status = true;
                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor editado com sucesso";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x=>x.Id== idAutor);
                if( autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado";
                    return resposta;
                }
                _context.Remove(autor);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor excluido com sucesso ";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutoresAsync()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autores = await _context.Autores.ToListAsync();
                if(autores != null)
                {
                    resposta.Dados = autores;
                    resposta.Mensagem = "Dados encontrados com sucesso";
                    resposta.Status = true;
                }
                else
                {
                    resposta.Dados = null!;
                    resposta.Mensagem = "Lista vazia";
                    resposta.Status = true;
                }

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
