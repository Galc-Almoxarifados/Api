using ApiTcc.Data;
using ApiTcc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTccAtt.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StatusItemController : ControllerBase
    {
        private readonly DataContext _context;
         private readonly IConfiguration _configuration;
         public StatusItemController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        
            [HttpGet("GetAllStatusItem")]
        public async Task<IActionResult> ListarTipoStatusItens()
        {
            try{
             
               List<StatusItem> lista = await _context.StatusItem.ToListAsync();
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
                StatusItem i = await _context.StatusItem
                
                    .FirstOrDefaultAsync(iBusca => iBusca.idStatusItem == id);

                    return Ok(i);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

         [HttpPut]
        public async Task<IActionResult> Update(StatusItem statusItemAtualizado)
        {
            try{
                _context.StatusItem.Update(statusItemAtualizado);
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