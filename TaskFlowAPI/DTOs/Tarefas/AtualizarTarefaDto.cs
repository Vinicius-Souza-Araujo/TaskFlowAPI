using System.ComponentModel.DataAnnotations;

namespace TaskFlowAPI.DTOs.Tarefas
{
    public class AtualizarTarefaDto
    {
        [Required(ErrorMessage = "O título da tarefa é obrigatório.")]
        [StringLength(150, ErrorMessage = "O título deve ter no máximo 150 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O status da tarefa é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O status informado é inválido.")]
        public int Status { get; set; }

        [Required(ErrorMessage = "A prioridade da tarefa é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A prioridade informada é inválida.")]
        public int Prioridade { get; set; }

        public DateOnly? DataVencimento { get; set; }

        [Required(ErrorMessage = "O projeto é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID do projeto informado é inválido.")]
        public int ProjetoId { get; set; }
    }
}
