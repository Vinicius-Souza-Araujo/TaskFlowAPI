using System.ComponentModel.DataAnnotations;

namespace TaskFlowAPI.DTOs.Projetos
{
    public class AtualizarProjetoDto
    {
        [Required(ErrorMessage = "O nome do projeto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do projeto deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; }
    }
}
