namespace TaskFlowAPI.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public bool Arquivado { get; set; } = false;
    }
}
