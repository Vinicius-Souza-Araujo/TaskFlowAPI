using Microsoft.EntityFrameworkCore;
using TaskFlowAPI.Data;
using TaskFlowAPI.Models;

namespace TaskFlowAPI.Repositories.Tarefas
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ApplicationDbContext _context;
        public TarefaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Tarefa> AdicionarAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> AtualizarAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa?> BuscarPorIdAsync(int id)
        {
            return await _context.Tarefas
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task ExcluirAsync(Tarefa tarefa)
        {      
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tarefa>> ListarPorProjetoAsync(int projetoId)
        {
            return await _context.Tarefas
                .AsNoTracking()
                .Where(t => t.ProjetoId == projetoId)
                .ToListAsync();
        }
    }
}
