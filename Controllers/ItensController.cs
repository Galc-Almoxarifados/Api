using ApiTcc.Data;
using ApiTcc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTcc.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ItensController : ControllerBase
    {
        private readonly DataContext _context;
        public ItensController(DataContext context)
        {
            _context = context;
        }
        
          [HttpGet("GetAllItens")]
        public async Task<IActionResult> Get()
        {
            try{
             
               List<Itens> lista = await _context.Itens.ToListAsync();
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
                Itens i = await _context.Itens
                
                    .FirstOrDefaultAsync(iBusca => iBusca.idITem == id);

                    return Ok(i);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("{nome}")]
        public async Task <IActionResult> BuscarItensPorNome(string nome)
        {
            try 
            {
                Itens i = await _context.Itens
                
                    .FirstOrDefaultAsync(iBusca => iBusca.nome == nome);

                    return Ok(i);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       /* [HttpPost]
        public async Task<IActionResult> AddItem(Itens novoItem)
        {
            try
            {
                
                await _context.Itens.AddAsync(novoItem);
                await _context.SaveChangesAsync();
                return Ok(novoItem);
            }
            catch ( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        [HttpPost]
        public async Task<IActionResult> AdicionarItem (Itens novoitem)
        {
            await _context.Itens.AddAsync(novoitem);
            await _context.SaveChangesAsync();

            return Ok(novoitem);
        }
        


        [HttpPut]
        public async Task<IActionResult> Update(Itens ItemAtualizado)
        {
            try{
                _context.Itens.Update(ItemAtualizado);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarItemPorId(int id)
        {
            try
            {
                Itens deletarItem = await _context.Itens.FirstOrDefaultAsync(x => x.idITem == id);
                _context.Itens.Remove(deletarItem);
                await _context.SaveChangesAsync();

                return Ok(deletarItem);

            }
            catch(Exception ex)
            {
                return BadRequest (ex.Message);
            }
                
            

        }
    }
}