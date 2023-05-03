using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ApiTcc.Models
{
     [Table("TipodeItem")]
    public class TipodeItem
    {
       [Key]
       [Column("idTipodeItem")]
       public int idTipoItem {get; set;}

       [Column("dsTipodeItem")]
       public string? dsTipoItem { get; set; }

    }
}