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

        public DateTime Tidspunkt { get; set; }

        public decimal Temperatur { get; set; }

        public Bevaegelser(int id, DateTime tidspunkt, decimal temperatur)
        {
            Id = id;
            Tidspunkt = tidspunkt;
            Temperatur = temperatur;
        }


        public Bevaegelser()
        {

        }
    }

}
