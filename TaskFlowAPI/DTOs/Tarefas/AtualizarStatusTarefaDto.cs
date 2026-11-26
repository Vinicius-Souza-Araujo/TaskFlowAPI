using System.ComponentModel.DataAnnotations;

namespace TaskFlowAPI.DTOs.Tarefas
{
    public class AtualizarStatusTarefaDto
    {
        [Required(ErrorMessage = "O status da tarefa é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O status informado é inválido.")]
        public int Status { get; set; }
    }
}
