using ApiTcc.Data;
using ApiTcc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTcc.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class AgendamentoController : ControllerBase
    {

         private readonly DataContext _context;
        public AgendamentoController(DataContext context)
        {
            _context = context;
        }

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
            await _context.Agendamento.AddAsync(novoAgendamento);
            await _context.SaveChangesAsync();

            return Ok(novoAgendamento);
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
}
}