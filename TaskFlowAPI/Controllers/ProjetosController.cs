using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlowAPI.DTOs.Projetos;
using TaskFlowAPI.Services.Projetos;

namespace TaskFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetosController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjetoResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProjetoResponseDto>> BuscarPorId(int id)
        {
            var projeto = await _projetoService.BuscarPorIdAsync(id);

            if (projeto == null)
                return NotFound();

            return Ok(projeto);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProjetoResponseDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProjetoResponseDto>>> Listar([FromQuery] bool? arquivado)
        {
            var projetos = await _projetoService.ListarAsync(arquivado);

            return Ok(projetos);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProjetoResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProjetoResponseDto>> Adicionar([FromBody] CriarProjetoDto dto)
        { 
            var projetoCriado = await _projetoService.AdicionarAsync(dto);
            return StatusCode(StatusCodes.Status201Created, projetoCriado);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProjetoResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProjetoResponseDto>> Atualizar(int id,[FromBody] AtualizarProjetoDto dto)
        {
            var projetoAtualizado = await _projetoService.AtualizarAsync(id, dto);

            if (projetoAtualizado == null)
                return NotFound();

            return Ok(projetoAtualizado);
        }

        [HttpPatch("{id}/arquivamento")]
        [ProducesResponseType(typeof(ProjetoResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProjetoResponseDto>> AtualizarArquivamento(int id,[FromBody] AtualizarArquivamentoProjetoDto dto)
        {
            var projetoAtualizado = await _projetoService.AtualizarArquivamentoAsync(id, dto.Arquivado!.Value);

            if (projetoAtualizado == null)
                return NotFound();

            return Ok(projetoAtualizado);
        }
    }
}
