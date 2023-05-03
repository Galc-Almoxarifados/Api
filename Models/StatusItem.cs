using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;
using RpgApi.Models;

namespace ApiTcc.Models
{
    [Table("StatusItem")]
    public class StatusItem
    {
        [Key]
        [Column("idStatusItem")]
        public int idStatusItem { get; set; }

        [Column("dsStatusItem")]
        public string? dsStatusItem { get; set; }

        [Column("diStatusItem")]
        public char diStatusItem { get; set; }
    }
}