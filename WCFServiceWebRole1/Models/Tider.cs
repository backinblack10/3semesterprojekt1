using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace WCFServiceWebRole1.Models
{
    [DataContract]
    [Table("Tider")]
    public class Tider
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public TimeSpan Fra { get; set; }

        [DataMember]
        public TimeSpan Til { get; set; }
    }
}
