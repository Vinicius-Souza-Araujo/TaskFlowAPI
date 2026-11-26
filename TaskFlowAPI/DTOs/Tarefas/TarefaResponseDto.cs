namespace TaskFlowAPI.DTOs.Tarefas
{
    public class TarefaResponseDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int Status { get; set; }
        public int Prioridade { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateOnly? DataVencimento { get; set; }
        public int ProjetoId { get; set; }
    }
}
