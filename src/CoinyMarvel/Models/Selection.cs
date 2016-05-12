using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hegemony.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hegemony.Models
{
    [Table("Selections")]
    public class Selection
    {
        [Key]
        public int ArmyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}