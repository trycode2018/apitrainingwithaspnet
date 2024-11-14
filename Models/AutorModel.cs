using System.Text.Json.Serialization;

namespace LivroApi.Models
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Nome {  get; set; } = string.Empty;
        public string Sobrenome {  get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<LivroModel>? Livro { get; set; }
    }
}
