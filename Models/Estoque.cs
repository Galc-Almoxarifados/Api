using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ApiTcc.Models
{
    [Table("Estoque")]
    public class Estoque 
    {
       [Key]
       [Column("UUID")]
       public int UUID { get; set; }

       [Column("idResponsavel")]
       public int idREsponsavel { get; set; }

       [Column("idAlmoxarife")]
       public int idAlmoxarife { get; set; }

       [Column("idItem")]       
       public int idItem { get; set; }

       [Column("mtMovimentacao")]
       public DateTime mtMovimentacao { get; set; }    

       [Column("idTipoMovimentacao")]
       public int idTipoMovimentacao { get; set; }

       [Column("qtMovimentacao")]
       public int qtMovimentacao { get; set; }



    }
}