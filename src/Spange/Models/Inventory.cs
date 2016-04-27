using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spange.Models
{
    [Table("Inventories")]
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; }
        [ForeignKey("GearId")]
        public int GearId { get; set; }
    }
}
