using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiTcc.Data;
using ApiTcc.Models;
using ApiTcc.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ApiTcc.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class UtilizadoresController : ControllerBase
    {
         private readonly DataContext _context;
         private readonly IConfiguration _configuration;
        public UtilizadoresController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private async Task<bool> UsuarioExistente (string em)
        {
            if(await _context.Utilizadores.AnyAsync(x => x.emUtilizador == em))
            {
                return true;
            }
            return false;
        }
        [AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUtilizador(Utilizadores em)
        {
            try 
            {
                if(await UsuarioExistente(em.emUtilizador))
                   throw new System.Exception("esse Email já está cadastrado");

                   Criptografia.CriarPasswordHash(em.passwordString, out byte[] hash, out byte[] salt);
                   em.passwordString = string.Empty;
                   em.PasswordHash = hash;
                   em.passwordSalt = salt;
                   await _context.Utilizadores.AddAsync(em);
                   await _context.SaveChangesAsync();

                   return Ok(em.nmUtilizador);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUtilizador(Utilizadores credenciais)
        {
            try
            {
                Utilizadores utilizadores = await _context.Utilizadores
                   .FirstOrDefaultAsync(x => x.emUtilizador.Equals(credenciais.emUtilizador));

                if ( utilizadores == null)
                    throw new System.Exception("Utilizador não foi encontrado.");
                else if (!Criptografia.VerificarPasswordHash(credenciais.passwordString, utilizadores.PasswordHash, utilizadores.passwordSalt))
                    throw new System.Exception("Senha incorreta.");
                else
                {
            
                    _context.Utilizadores.Update(utilizadores);
                    await _context.SaveChangesAsync(); //Confirma a alteração no banco
                    
                    utilizadores.PasswordHash = null;
                    utilizadores.PasswordHash = null;
                    utilizadores.Token = CriarToken(utilizadores);
                    return Ok(utilizadores);
                    
                }
            }
            catch (System.Exception ex)

            { 
                return BadRequest(ex.Message); 
            }
        }
        [AllowAnonymous]
        [HttpPut("AlterarSenha")]
        public async Task<IActionResult> AlterarSenhaUtilizador(Utilizadores credenciais)
        {
            try
            {
                Utilizadores utilizadores = await _context.Utilizadores //Busca o usuário no banco através do email
                   .FirstOrDefaultAsync(x => x.emUtilizador.Equals(credenciais.emUtilizador));

                if (utilizadores == null) //Se não achar nenhum professor pelo email, retorna mensagem.
                    throw new System.Exception("Utilizador não foi encontrado.");

                Criptografia.CriarPasswordHash(credenciais.passwordString, out byte[] hash, out byte[] salt);
                utilizadores.PasswordHash = hash; //Se o utilizador existir, executa a criptografia
                utilizadores.passwordSalt = salt; //guardando o hash e o salt nas propriedades do utilizador 

                _context.Utilizadores.Update(utilizadores);
                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    

        [HttpGet("GetAll")]
        
        public async Task<IActionResult> GetUtilizadores()
        {
            try
            {
                //List exigirá o using System.Collections.Generic
                List<Utilizadores> lista = await _context.Utilizadores.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

         [HttpGet("{utiliazdorId}")]
        public async Task<IActionResult> GetUtilizadores(int idUtilizador)
        {
            try
            {
                //List exigirá o using System.Collections.Generic
                Utilizadores utilizadores = await _context.Utilizadores //Busca o usuário no banco através do Id
                   .FirstOrDefaultAsync(x => x.idUtilizador== idUtilizador);

                return Ok(utilizadores);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

         [HttpGet("GetByLogin/{login}")]
        public async Task<IActionResult> GetUsuario(string login)
        {
            try
            {
                //List exigirá o using System.Collections.Generic
                Utilizadores utilizadores = await _context.Utilizadores //Busca o usuário no banco através do login
                   .FirstOrDefaultAsync(x => x.nmUtilizador.ToLower() == login.ToLower());

                return Ok(utilizadores);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Método para alteração do e-mail
        [AllowAnonymous]
        [HttpPut("AtualizarEmail")]
        public async Task<IActionResult> AtualizarEmail(Utilizadores u)
        {
            try
            {
                Utilizadores utilizadores = await _context.Utilizadores //Busca o usuário no banco através do Id
                   .FirstOrDefaultAsync(x => x.idUtilizador == u.idUtilizador);

                utilizadores.emUtilizador = u.emUtilizador;                

                var attach = _context.Attach(utilizadores);
                attach.Property(x => x.idUtilizador).IsModified = false;
                attach.Property(x => x.emUtilizador).IsModified = true;                

                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       private string CriarToken(Utilizadores utilizadores)
        {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, utilizadores.idUtilizador.ToString()),
            new Claim(ClaimTypes.Name, utilizadores.nmUtilizador),
            new Claim(ClaimTypes.Role, utilizadores.Perfil)
            
        };


            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_configuration.GetSection("ConfiguracaoToken:Chave").Value));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        
        
    }
}