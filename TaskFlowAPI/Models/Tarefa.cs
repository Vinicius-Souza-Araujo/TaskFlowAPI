namespace TaskFlowAPI.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int Status { get; set; }
        public int Prioridade { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateOnly? DataVencimento { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; } = null!;
    }
}
