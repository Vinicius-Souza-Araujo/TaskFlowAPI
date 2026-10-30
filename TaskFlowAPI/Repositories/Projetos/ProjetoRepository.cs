using Microsoft.EntityFrameworkCore;
using TaskFlowAPI.Data;
using TaskFlowAPI.Models;

namespace TaskFlowAPI.Repositories.Projetos
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjetoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Projeto?> BuscarPorIdAsync(int id)
        {
            return await _context.Projetos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<Projeto>> ListarAsync(bool? arquivado)
        {
            var query = _context.Projetos.AsNoTracking();
            if (arquivado.HasValue)
               query = query.Where(p => p.Arquivado == arquivado.Value);
            return await query
                .OrderBy(p => p.Id)
                .ToListAsync();
        }

        public async Task<Projeto> AdicionarAsync(Projeto projeto)
        {
            await _context.Projetos.AddAsync(projeto);
            await _context.SaveChangesAsync();
            return projeto;
        }

        public async Task<Projeto> AtualizarAsync(Projeto projeto)
        {
            _context.Projetos.Update(projeto);
            await _context.SaveChangesAsync();
            return projeto;
        }
    }
}
