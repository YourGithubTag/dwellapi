using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DwellAPI.Model
{
    public partial class Items
    {
        [Column("id")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        [StringLength(50)]
        public string Tags { get; set; }
        [StringLength(50)]
        public string ItemName { get; set; }
        [StringLength(50)]
        public string Room { get; set; }
    }
}
