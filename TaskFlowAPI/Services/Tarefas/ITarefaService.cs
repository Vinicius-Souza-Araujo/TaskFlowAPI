using TaskFlowAPI.DTOs.Tarefas;

namespace TaskFlowAPI.Services.Tarefas
{
    public interface ITarefaService
    {
        Task<TarefaResponseDto> AdicionarAsync(CriarTarefaDto dto);
        Task<List<TarefaResponseDto>> ListarPorProjetoAsync(int projetoId);
        Task<TarefaResponseDto?> BuscarPorIdAsync(int id);
        Task<TarefaResponseDto?> AtualizarAsync(int id, AtualizarTarefaDto dto);
        Task<bool> ExcluirAsync(int id);

    }
}
