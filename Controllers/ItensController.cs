using System.Security.Claims;
using ApiTcc.Data;
using ApiTcc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTcc.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class ItensController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public ItensController(DataContext context, IHttpContextAccessor httpContextAccessor, IConfiguration configuration )
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
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


        private async Task<bool> ItemExistente (string nomeItem)
        {
            return await _context.Itens.AnyAsync(x => x.nome == nomeItem);

        }

        [HttpPost("RegistrarItem")]
        public async Task<IActionResult> AdicionarItem (Itens novoitem)
        {
            try
            {

                if(await ItemExistente(novoitem.nome))
                   throw new System.Exception("este item já foi cadastrado");

                /*int utilizadorId = int.Parse(_httpContextoAcessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                novoitem.Utilizadores = _context.Utilizadores.FirstOrDefault(uBuscar => uBuscar.idUtilizador == utilizadorId); */  


            await _context.Itens.AddAsync(novoitem);
            await _context.SaveChangesAsync();

            return Ok(novoitem);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
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

        private int ObterUtilizadorId()
            {
                return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            private string ObterPerfilUtilizador()
            {
                return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            }
    }
}