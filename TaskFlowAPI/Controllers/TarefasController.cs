using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlowAPI.DTOs.Tarefas;
using TaskFlowAPI.Services.Tarefas;

namespace TaskFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _service;
        public TarefasController(ITarefaService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TarefaResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Adicionar([FromBody] CriarTarefaDto dto)
        {
            try
            {
                var tarefa = await _service.AdicionarAsync(dto);
                return StatusCode(StatusCodes.Status201Created, tarefa);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { mensagem = ex.Message });
            }
        }

        [HttpGet("/api/projetos/{projetoId:int}/tarefas")]
        [ProducesResponseType(typeof(List<TarefaResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListarPorProjeto(int projetoId)
        {
            try
            {
                var tarefas = await _service.ListarPorProjetoAsync(projetoId);

                return Ok(tarefas);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(TarefaResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorId ([FromRoute] int id)
        {
            var tarefa = await _service.BuscarPorIdAsync(id);

            if (tarefa == null)
                return NotFound();

            return Ok(tarefa);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(TarefaResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] AtualizarTarefaDto dto)
        {
            try
            {
                var tarefa = await _service.AtualizarAsync(id, dto);

                if (tarefa == null)
                    return NotFound();

                return Ok(tarefa);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Excluir([FromRoute] int id)
        {
            var excluida = await _service.ExcluirAsync(id);

            if (!excluida)
                return NotFound();

            return NoContent();
        }
    }
}
