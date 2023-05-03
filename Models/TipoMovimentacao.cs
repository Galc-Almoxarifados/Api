using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTcc.Models
{
    [Table("TipoMovimentacao")]
    public class TipoMovimentacao 
    {
        [Key]
        [Column("idTipoMovimentacao")]
        public int idTipoMovimentacao { get; set; }

        [Column("dsTipoMovimentacao")]
        public string? dsTipoMovimentacao { get; set; }

        [Column("snTipoMvimentacao")]
        public char snTipoMvimentacao { get; set; }





        
    }
}