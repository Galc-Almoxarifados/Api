using ApiTcc.Data;
using ApiTcc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTccAtt.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TipoUtilizadorController : ControllerBase
    {
        private readonly DataContext _context;
         private readonly IConfiguration _configuration;
         public TipoUtilizadorController(DataContext context, IConfiguration configuration)
        
        {
            _context = context;
            _configuration = configuration;
        }
        
         [HttpGet("GetAllTipoUtilizadore")]
        public async Task<IActionResult> ListarTipoUtilizador()
        {
            try{
             
               List<TipoUtilizador> lista = await _context.TipoUtilizador.ToListAsync();
               return Ok(lista);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetIdTipoUtilizador(int id)
        {
            try 
            {
                TipoUtilizador i = await _context.TipoUtilizador
                
                    .FirstOrDefaultAsync(iBusca => iBusca.idTipoUtilizador == id);
                    

                    return Ok(i);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

         [HttpPut]
        public async Task<IActionResult> Update(TipoUtilizador TipoUtilizadorAtualizado)
        {
            try{
                _context.TipoUtilizador.Update(TipoUtilizadorAtualizado);
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