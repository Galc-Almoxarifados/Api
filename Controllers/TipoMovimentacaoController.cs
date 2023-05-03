using Microsoft.AspNetCore.Mvc;
using ApiTcc.Data;
using Microsoft.EntityFrameworkCore;
using ApiTcc.Models;

namespace ApiTccAtt.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TipoMovimentacaoController : ControllerBase
    {

        private readonly DataContext _context;
         private readonly IConfiguration _configuration;
         public TipoMovimentacaoController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        
            [HttpGet("GetAllTipoMovimentacao")]
        public async Task<IActionResult> ListarTipoMovimentaco()
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
                TipoMovimentacao i = await _context.TipoMovimentacao
                
                    .FirstOrDefaultAsync(iBusca => iBusca.idTipoMovimentacao == id);

                    return Ok(i);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

         [HttpPut]
        public async Task<IActionResult> Update(TipoMovimentacao tipoMovimentacaoAtualizado)
        {
            try{
                _context.TipoMovimentacao.Update(tipoMovimentacaoAtualizado);
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