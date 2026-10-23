using System.ComponentModel.DataAnnotations;

namespace TaskFlowAPI.DTOs.Projetos
{
    public class AtualizarArquivamentoProjetoDto
    {
        [Required(ErrorMessage = "O campo Arquivado é obrigatório.")]
        public bool? Arquivado { get; set; }
    }
}
