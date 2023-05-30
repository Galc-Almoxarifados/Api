using ApiTcc.Data;
using ApiTcc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTccAtt.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ItemEquipamentoController : ControllerBase
    {
         private readonly DataContext _context;
         private readonly IConfiguration _configuration;
         public ItemEquipamentoController(DataContext context, IConfiguration configuration)
        
        {
            _context = context;
            _configuration = configuration;
        }

         [HttpGet("GetAllItemEquipamento")]
        public async Task<IActionResult> ListarItemEquipamento()
        {
            try{
             
               List<Item_Equipamento> lista = await _context.Item_Equipamento.ToListAsync();
               return Ok(lista);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetIdEquipamento(int id)
        {
            try 
            {
                Item_Equipamento i = await _context.Item_Equipamento
                
                    .FirstOrDefaultAsync(iBusca => iBusca.idEquipamentos == id);
                    

                    return Ok(i);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


         [HttpPut]
        public async Task<IActionResult> Update(Item_Equipamento ItemEquipamentoAtualizado)
        {
            try{
                _context.Item_Equipamento.Update(ItemEquipamentoAtualizado);
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