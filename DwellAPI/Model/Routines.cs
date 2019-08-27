using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DwellAPI.Model
{
    public partial class Routines
    {
        [Column("id")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Descript { get; set; }
        [StringLength(50)]
        public string RoutineName { get; set; }
    }
}
