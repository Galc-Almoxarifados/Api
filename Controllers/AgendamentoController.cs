using System.Security.Claims;
using ApiTcc.Data;
using ApiTcc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTcc.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class AgendamentoController : ControllerBase
    {

         private readonly DataContext _context;
         private readonly IHttpContextAccessor _httpContextAccessor;
        public AgendamentoController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
         [HttpGet("GetAllAgendamentos")]
        public async Task<IActionResult> ListarAgendamentos()
        {
            try{
             
               List<Agendamento> lista = await _context.Agendamento.ToListAsync();
               return Ok(lista);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }


         [HttpPost]
        public async Task<IActionResult> AdicionarAgendamento (Agendamento novoAgendamento)
        {
            try
            {
            await _context.Agendamento.AddAsync(novoAgendamento);
            await _context.SaveChangesAsync();

            return Ok(novoAgendamento);

            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }

            
        }

         [HttpPut]
        public async Task<IActionResult> AlterarAgendamento(Agendamento agendamentoAtualizado)
        {
            try{
                _context.Agendamento.Update(agendamentoAtualizado);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAgendamentoPorId(int id)
        {
            try
            {
                Agendamento deletarAgendamento = await _context.Agendamento.FirstOrDefaultAsync(x => x.idAgendamento == id);
                _context.Agendamento.Remove(deletarAgendamento);
                await _context.SaveChangesAsync();

                return Ok(deletarAgendamento);

            }
            catch(Exception ex)
            {
                return BadRequest (ex.Message);
            }

        

        
    }

    private int ObterUsuarioId()
            {
                return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            private string ObterPerfilUsuario()
            {
                return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            }
}
}