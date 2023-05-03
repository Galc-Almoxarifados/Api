using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ApiTcc.Models;


namespace RpgApi.Models
{
    [Table("Equipamentos")]
    public class Equipamentos
    {    
        [Key]   
        [Column("idEquipamentos")]
        public int idEquipamentos { get; set; }

        [Column("idStatusItem")]
        public int idStatusItem { get; set; }

        [Column("nmEquipamento")]
        public string? nmEquipamento { get; set; }

        [Column("dsEquipamento")]
        public string? dsEquipamento { get; set; }

        [Column("nsEquipamento")]
        public string? nsEquipamento { get; set; }

        [Column("pnEquipamento")]
        public string? pnEquipamento { get; set; }
    }
}