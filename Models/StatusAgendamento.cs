using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ApiTcc.Models
{
    [Table("StatusAgendamento")]
    public class SatatusAgendamento
    {
        [Key]
        [Column("idStatusAgendamento")]
        public int idStatusAgendamento { get; set; }

        [Column("dsStatusAgendamento")]
        public string? dsStatusAgendamento { get; set; }


    }
}