using ApiTcc.Data;
using ApiTcc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTccAtt.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TipodeItemController : ControllerBase
    {

        private readonly DataContext _context;
         private readonly IConfiguration _configuration;
         public TipodeItemController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        
            [HttpGet("GetAllTipodeItem")]
        public async Task<IActionResult> ListarTipodeItem()
        {
            try{
             
               List<TipodeItem> lista = await _context.TipodeItem.ToListAsync();
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
                TipodeItem i = await _context.TipodeItem
                
                    .FirstOrDefaultAsync(iBusca => iBusca.idTipoItem == id);

                    return Ok(i);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

         [HttpPut]
        public async Task<IActionResult> Update(TipodeItem TipodeItemAtualizado)
        {
            try{
                _context.TipodeItem.Update(TipodeItemAtualizado);
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