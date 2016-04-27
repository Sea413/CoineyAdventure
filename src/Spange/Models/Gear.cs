using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spange.Models
{
    [Table("Gears")]
    public class Gear
    {
        [Key]
        public int GearId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int ThreatBonus { get; set; }
        public int SympathyBonus { get; set; }
        public int PitchBonus { get; set; }
        public int CookBonus { get; set; }
        public double StreetPrice { get; set; }

        public double GutterPrice { get; set; }
    }
}