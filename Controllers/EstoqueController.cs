using ApiTcc.Data;
using ApiTcc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

     

namespace ApiTcc.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly DataContext _context;
        public EstoqueController(DataContext context)
        {
            _context = context;
        }

       
        [HttpGet("GetAllEstoque")]
        public async Task<IActionResult> Get()
        {
            try{
             
               List<Estoque> lista = await _context.Estoque.ToListAsync();
               return Ok(lista);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> BuscarItemEquipamentoPorId(int id)
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
        public async Task <IActionResult> BuscarItemEquipamentoPorNome(string nome)
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

         [HttpPut]
        public async Task<IActionResult> AlterarEstoque (Estoque alteradoEstoque)
        {
            try
            {
            _context.Estoque.Update(alteradoEstoque);
            await _context.SaveChangesAsync();

            return Ok(alteradoEstoque);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Excluir (int id)
        {
            try
            {
                 Estoque pRemover = await _context.Estoque.FirstOrDefaultAsync(p => p.idItem == id);

            _context.Estoque.Remove(pRemover);
            await _context.SaveChangesAsync();
            return Ok(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
           
        }
    }
}
/*
 [HttpGet("GetAllItensEstoque")]
        public async Task<IActionResult> Get()
        {
            try{
             
               List<Estoque> lista = await _context.Estoque.ToListAsync();
               return Ok(lista);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarItem (Estoque novoItem)
        {
            await _context.Estoque.AddAsync(novoItem);
            await _context.SaveChangesAsync();

            return Ok(novoItem);
        }

        [HttpPut]
        public async Task<IActionResult> AlterarItens (Estoque itemAlterado)
        {
             _context.Estoque.Update(itemAlterado);
            await _context.SaveChangesAsync();

            return Ok(itemAlterado);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> ExcluirItem (int id)
        {
            Estoque pRemover = await _context.Estoque.FirstOrDefaultAsync(p => p.idItem == id);

            _context.Estoque.Remove(pRemover);
            await _context.SaveChangesAsync();
            return Ok(id);
        }
*/
  