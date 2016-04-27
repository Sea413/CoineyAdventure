using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spange.Models
{
    [Table("Drugs")]
    public class Drug
    {
        [Key]
        public int DrugId { get; set; }

        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; }

        public string Name { get; set; }
        public int Damage { get; set; }
        public string ThreatBonus { get; set; }
        public string AppealBonus { get; set; }
        public int SleepBonus { get; set; }
        public int CookBonus { get; set; }
        public double StreetPrice { get; set; }
        public double GutterPrice { get; set; }
    }
}