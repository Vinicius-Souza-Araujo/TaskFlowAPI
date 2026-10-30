using TaskFlowAPI.DTOs.Projetos;
using TaskFlowAPI.Models;

namespace TaskFlowAPI.Services.Projetos
{
    public interface IProjetoService
    {
        Task<List<ProjetoResponseDto>> ListarAsync(bool? arquivado);
        Task<ProjetoResponseDto> AdicionarAsync(CriarProjetoDto dto);
        Task<ProjetoResponseDto?> BuscarPorIdAsync(int id);
        Task<ProjetoResponseDto?> AtualizarAsync(int id, AtualizarProjetoDto dto);
        Task<ProjetoResponseDto?> AtualizarArquivamentoAsync(int id, bool arquivado);
    }
}
