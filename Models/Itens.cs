using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ApiTcc.Models
{
    [Table("Itens")]
    public class Itens
    {
        [Key]
        // [JsonIgnore]
       [Column("idITem")]
       public int idITem { get; set; }

       [Column("idAlmoxarife")]
       public int idAlmoxarife {get; set;}

       [Column("idStatusItem")]       
       public int idStatusItem { get; set; }

       [Column("idTipodeItem")]       
       public int idTipodeItem { get; set; }

       [Column("nome")]
       public string? nome { get; set; }

       [Column("qtItens")]
       public int qtItens { get; set; }    

       [Column("dcItem")]
       public DateTime dcItem { get; set; }

       [Column("daItem")]
       public DateTime daItem { get; set; }
    }
}