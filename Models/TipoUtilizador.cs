using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace ApiTcc.Models
{
    [Table("TipoUtilizador")]
     public class TipoUtilizador 
    {
        [Key]
        [Column("idTipoUtilizador")]
        public int idTipoUtilizador { get; set; }

        [Column("dsTipoUtilizador")]
        public string? dsTipoUtilizador { get; set; }

    }
}