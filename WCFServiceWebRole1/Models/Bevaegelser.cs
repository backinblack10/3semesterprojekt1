using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace WCFServiceWebRole1.Models
{


    [Table("Bevaegelser")]
    public partial class Bevaegelser
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Dato { get; set; }

        public TimeSpan Tidspunkt { get; set; }

        public decimal Temperatur { get; set; }
    }
}
