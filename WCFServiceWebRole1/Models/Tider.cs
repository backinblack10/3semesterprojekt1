namespace WCFServiceWebRole1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tider")]
    public partial class Tider
    {
        public int Id { get; set; }

        public TimeSpan Fra { get; set; }

        public TimeSpan Til { get; set; }
    }
}
