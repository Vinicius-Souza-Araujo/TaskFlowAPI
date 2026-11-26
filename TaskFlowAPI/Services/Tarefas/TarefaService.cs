using TaskFlowAPI.DTOs.Tarefas;
using TaskFlowAPI.Models;
using TaskFlowAPI.Repositories.Projetos;
using TaskFlowAPI.Repositories.Tarefas;

namespace TaskFlowAPI.Services.Tarefas
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IProjetoRepository _projetoRepository;

        public TarefaService(ITarefaRepository tarefaRepository, IProjetoRepository projetoRepository)
        {
            _tarefaRepository = tarefaRepository;
            _projetoRepository = projetoRepository;
        }

        public async Task<TarefaResponseDto> AdicionarAsync(CriarTarefaDto dto)
        {
            var projeto = await _projetoRepository.BuscarPorIdAsync(dto.ProjetoId);

            if (projeto == null)
                throw new KeyNotFoundException("O projeto informado não existe.");

            if (projeto.Arquivado)
                throw new InvalidOperationException("Não é possível criar tarefas em projetos arquivados.");

            var tarefa = new Tarefa
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Status = dto.Status,
                Prioridade = dto.Prioridade,
                DataVencimento = dto.DataVencimento,
                ProjetoId = dto.ProjetoId
            };

            var tarefaCriada = await _tarefaRepository.AdicionarAsync(tarefa);

            return new TarefaResponseDto
            {
                Id = tarefaCriada.Id,
                Titulo = tarefaCriada.Titulo,
                Descricao = tarefaCriada.Descricao,
                Status = tarefaCriada.Status,
                Prioridade = tarefaCriada.Prioridade,
                DataCriacao = tarefaCriada.DataCriacao,
                DataVencimento = tarefaCriada.DataVencimento,
                ProjetoId = tarefaCriada.ProjetoId
            };
        }

        public async Task<TarefaResponseDto?> AtualizarAsync(int id, AtualizarTarefaDto dto)
        {
            var tarefa = await _tarefaRepository.BuscarPorIdAsync(id);

            if (tarefa == null)
                return null;

            var projeto = await _projetoRepository.BuscarPorIdAsync(dto.ProjetoId);

            if (projeto == null)
                throw new KeyNotFoundException("O projeto informado não existe.");

            if (projeto.Arquivado)
                throw new InvalidOperationException("Não é possível associar tarefas a projetos arquivados.");

            tarefa.Titulo = dto.Titulo;
            tarefa.Descricao = dto.Descricao;
            tarefa.Status = dto.Status;
            tarefa.Prioridade = dto.Prioridade;
            tarefa.DataVencimento = dto.DataVencimento;
            tarefa.ProjetoId = dto.ProjetoId;

            var tarefaAtualizada = await _tarefaRepository.AtualizarAsync(tarefa);

            return new TarefaResponseDto
            {
                Id = tarefaAtualizada.Id,
                Titulo = tarefaAtualizada.Titulo,
                Descricao = tarefaAtualizada.Descricao,
                Status = tarefaAtualizada.Status,
                Prioridade = tarefaAtualizada.Prioridade,
                DataCriacao = tarefaAtualizada.DataCriacao,
                DataVencimento = tarefaAtualizada.DataVencimento,
                ProjetoId = tarefaAtualizada.ProjetoId
            };
        }

        public async Task<TarefaResponseDto?> BuscarPorIdAsync(int id)
        {
            var tarefa = await _tarefaRepository.BuscarPorIdAsync(id);

            if (tarefa == null)
                return null;

            return new TarefaResponseDto
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status,
                Prioridade = tarefa.Prioridade,
                DataCriacao = tarefa.DataCriacao,
                DataVencimento = tarefa.DataVencimento,
                ProjetoId = tarefa.ProjetoId
            };
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var tarefa = await _tarefaRepository.BuscarPorIdAsync(id);
            
            if (tarefa == null)
                return false;

            await _tarefaRepository.ExcluirAsync(tarefa);

            return true;
        }

        public async Task<List<TarefaResponseDto>> ListarPorProjetoAsync(int projetoId)
        {
            var projetoExiste = await _projetoRepository.ExisteAsync(projetoId);

            if (!projetoExiste)
                throw new KeyNotFoundException("O projeto informado não existe.");

            var tarefas = await _tarefaRepository.ListarPorProjetoAsync(projetoId);

            return tarefas.Select(t => new TarefaResponseDto
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descricao = t.Descricao,
                Status = t.Status,
                Prioridade = t.Prioridade,
                DataCriacao = t.DataCriacao,
                DataVencimento = t.DataVencimento,
                ProjetoId = t.ProjetoId
            }).ToList();
        }
    }
}
