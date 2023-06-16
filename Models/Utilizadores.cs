using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTcc.Models
{
    [Table("Utilizadores")]
    public class Utilizadores
    {
         [Key]
        [Column("idUtilizador")]
        public int idUtilizador { get; set; }

        [Column("nmUtilizador")]
        public string? nmUtilizador { get; set; }

        [Column("dcUtilizador")]
        public DateTime dcUtilizador { get; set; } = DateTime.Now;

        [Column("emUtilizador")]
        public string? emUtilizador { get; set; }

        [Column("passwordSalt")]
        public Byte[]? passwordSalt { get; set; }
        
        [Column("PasswordHash")]
        public Byte[]? PasswordHash { get; set; }

        [Column("Perfil")]
        public string? Perfil { get; set; }

        [NotMapped]
        public string? passwordString {get; set;}

        [NotMapped]
        public string? Token {get; set;}
        //[NotMapped]
        //[Required]
        


 
        
    }
}