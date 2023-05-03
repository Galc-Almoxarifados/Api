using ApiTcc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models;

namespace ApiTcc.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class EquipamentoController : ControllerBase
    {
         private readonly DataContext _context;
        public EquipamentoController(DataContext context)
        {
            _context = context;
        }

        
          [HttpGet("GetAllEquipamentos")]
        public async Task<IActionResult> BuscarEquipamentos()
        {
            try{
             
               List<Equipamentos> lista = await _context.Equipamentos.ToListAsync();
               return Ok(lista);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> BuscarEquipamentoPorId(int id)
        {
            try 
            {
                Equipamentos i = await _context.Equipamentos
                
                    .FirstOrDefaultAsync(iBusca => iBusca.idEquipamentos == id);

                    return Ok(i);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

         [HttpGet("{nome}")]
        public async Task <IActionResult> BuscarEquipamentoPorNome(string nome)
        {
            try 
            {
                Equipamentos i = await _context.Equipamentos
                
                    .FirstOrDefaultAsync(iBusca => iBusca.nmEquipamento == nome);

                    return Ok(i);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEquipamento (Equipamentos novoEquipamento)
        {
            await _context.Equipamentos.AddAsync(novoEquipamento);
            await _context.SaveChangesAsync();

            return Ok(novoEquipamento);
        }

        [HttpPut]
        public async Task<IActionResult> AlterarEquipamentos(Equipamentos equipamentoAtualizado)
        {
            try{
                _context.Equipamentos.Update(equipamentoAtualizado);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarEquipamentoPorId(int id)
        {
            try
            {
                Equipamentos deletarEquipamento = await _context.Equipamentos.FirstOrDefaultAsync(x => x.idEquipamentos == id);
                _context.Equipamentos.Remove(deletarEquipamento);
                await _context.SaveChangesAsync();

                return Ok(deletarEquipamento);

            }
            catch(Exception ex)
            {
                return BadRequest (ex.Message);
            }




        
    }
}
}