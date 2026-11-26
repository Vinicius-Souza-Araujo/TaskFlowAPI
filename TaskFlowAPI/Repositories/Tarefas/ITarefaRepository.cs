using TaskFlowAPI.Models;

namespace TaskFlowAPI.Repositories.Tarefas
{
    public interface ITarefaRepository
    {
        Task<Tarefa> AdicionarAsync(Tarefa tarefa);
        Task<List<Tarefa>> ListarPorProjetoAsync(int projetoId);
        Task<Tarefa?> BuscarPorIdAsync(int id);
        Task<Tarefa> AtualizarAsync(Tarefa tarefa);
        Task ExcluirAsync(Tarefa tarefa);
    }
}
