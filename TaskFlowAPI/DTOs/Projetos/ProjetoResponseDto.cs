namespace TaskFlowAPI.DTOs.Projetos
{
    public class ProjetoResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Arquivado { get; set; }
    }
}
