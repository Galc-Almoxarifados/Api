using ApiTcc.Data;
using ApiTcc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTccAtt.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StatusAgendamentoController : ControllerBase
    {

         private readonly DataContext _context;
         private readonly IConfiguration _configuration;
         public StatusAgendamentoController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        
            [HttpGet("GetAllStatusAgendamento")]
        public async Task<IActionResult> ListarTipoStatusAgendamento()
        {
            try{
             
               List<TipoMovimentacao> lista = await _context.TipoMovimentacao.ToListAsync();
               return Ok(lista);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetSingle(int id)
        {
            try 
            {
                SatatusAgendamento i = await _context.StatusAgendamento
                
                    .FirstOrDefaultAsync(iBusca => iBusca.idStatusAgendamento == id);

                    return Ok(i);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

         [HttpPut]
        public async Task<IActionResult> Update(SatatusAgendamento statusAgendamentoAtualizado)
        {
            try{
                _context.StatusAgendamento.Update(statusAgendamentoAtualizado);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }
        
    }
}