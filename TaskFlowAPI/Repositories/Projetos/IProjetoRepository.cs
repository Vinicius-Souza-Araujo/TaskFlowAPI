using TaskFlowAPI.Models;

namespace TaskFlowAPI.Repositories.Projetos
{
    public interface IProjetoRepository
    {
        Task<Projeto?> BuscarPorIdAsync(int id);
        Task <List<Projeto>> ListarAsync(bool? arquivado);
        Task<Projeto> AdicionarAsync(Projeto projeto);
        Task<Projeto> AtualizarAsync(Projeto projeto);
    }
}
