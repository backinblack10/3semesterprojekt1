using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace WCFServiceWebRole1.Models
{
    [DataContract]
    [Table("Tider")]
    public partial class Tider
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public TimeSpan Fra { get; set; }

        [DataMember]
        public TimeSpan Til { get; set; }
    }
}
