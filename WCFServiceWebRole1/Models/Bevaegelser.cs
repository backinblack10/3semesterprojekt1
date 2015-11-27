using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace WCFServiceWebRole1.Models
{


    [Table("Bevaegelser")]
    [DataContract]
    public partial class Bevaegelser
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Column(TypeName = "date")]
        public DateTime Dato { get; set; }

        [DataMember]
        public TimeSpan Tidspunkt { get; set; }

        [DataMember]
        public decimal Temperatur { get; set; }

        public Bevaegelser(DateTime dato, TimeSpan tidspunkt, decimal temperatur)
        {
            Dato = dato;
            Tidspunkt = tidspunkt;
            Temperatur = temperatur;
        }

        public Bevaegelser()
        {
            
        }
    }
}
