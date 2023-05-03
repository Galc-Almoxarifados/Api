using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ApiTcc.Models
{
    [Table("Item_Equipamento")]
    public class Item_Equipamento
    {
        [Key]
        [Column("idItem")]
        public int idItem { get; set; }

        [Column("idEquipamentos")]
        public int idEquipamentos { get; set; }

        
    }
}