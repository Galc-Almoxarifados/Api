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

        [Column("nomeItem")]
        public string? nomeItem { get; set; }

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