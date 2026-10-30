using TaskFlowAPI.DTOs.Projetos;
using TaskFlowAPI.Models;
using TaskFlowAPI.Repositories.Projetos;

namespace TaskFlowAPI.Services.Projetos
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task<ProjetoResponseDto> AdicionarAsync(CriarProjetoDto dto)
        {
            var projeto = new Projeto
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao
            };

            var projetoCriado = await _projetoRepository.AdicionarAsync(projeto);

            return new ProjetoResponseDto
            {
                Id = projetoCriado.Id,
                Nome = projetoCriado.Nome,
                Descricao = projetoCriado.Descricao,
                DataCriacao = projetoCriado.DataCriacao,
                Arquivado = projetoCriado.Arquivado
            }; 
        }

        public async Task<ProjetoResponseDto?> AtualizarAsync(int id, AtualizarProjetoDto dto)
        {
            var projeto = await _projetoRepository.BuscarPorIdAsync(id);

            if (projeto == null)
                return null;

            projeto.Nome = dto.Nome;
            projeto.Descricao = dto.Descricao;

            var projetoAtualizado = await _projetoRepository
                .AtualizarAsync(projeto);

            return new ProjetoResponseDto
            {
                Id = projetoAtualizado.Id,
                Nome = projetoAtualizado.Nome,
                Descricao = projetoAtualizado.Descricao,
                DataCriacao = projetoAtualizado.DataCriacao,
                Arquivado = projetoAtualizado.Arquivado
            };
        }

        public async Task<ProjetoResponseDto?> AtualizarArquivamentoAsync(int id, bool arquivado)
        {
            var projeto = await _projetoRepository.BuscarPorIdAsync(id);

            if (projeto == null)
                return null;

            projeto.Arquivado = arquivado;

            var projetoAtualizado = await _projetoRepository
                .AtualizarAsync(projeto);

            return new ProjetoResponseDto
            {
                Id = projetoAtualizado.Id,
                Nome = projetoAtualizado.Nome,
                Descricao = projetoAtualizado.Descricao,
                DataCriacao = projetoAtualizado.DataCriacao,
                Arquivado = projetoAtualizado.Arquivado
            };
        }

        public async Task<ProjetoResponseDto?> BuscarPorIdAsync(int id)
        {
            var projeto = await _projetoRepository.BuscarPorIdAsync(id);

            if (projeto == null)
                return null;

            return new ProjetoResponseDto
            {
                Id = projeto.Id,
                Nome = projeto.Nome,
                Descricao = projeto.Descricao,
                DataCriacao = projeto.DataCriacao,
                Arquivado = projeto.Arquivado
            };
        }

        public async Task<List<ProjetoResponseDto>> ListarAsync(bool? arquivado)
        {
            var projetos = await _projetoRepository.ListarAsync(arquivado);

            return projetos.Select(projeto => new ProjetoResponseDto
            {
                Id = projeto.Id,
                Nome = projeto.Nome,
                Descricao = projeto.Descricao,
                DataCriacao = projeto.DataCriacao,
                Arquivado = projeto.Arquivado
            }).ToList();
        }
    }
}
