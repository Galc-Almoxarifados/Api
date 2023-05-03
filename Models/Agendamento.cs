using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTcc.Models
{
    [Table("Agendamento")]
    public class Agendamento
    {
        [Key]
        [Column("idAgendamento")]
        public int idAgendamento { get; set; }

        [Column("idStatusAgendamento")]
        public int idStatusAgendamento { get; set; }

        [Column("idResponsavel")]
        public int idResponsavel { get; set; }

        [Column("idItem")]
        public int idItem { get; set; }

        [Column("qtAgendamento")]
       public int qtAgendamento { get; set; }    

       [Column("mtAgendamento")]
       public DateTime mtAgendamento { get; set; }

       [Column("mtRetirada")]
       public DateTime mtRetirada { get; set; }

       [Column("mtDevolucao")]
       public DateTime mtDevolucao { get; set; }
    }
}