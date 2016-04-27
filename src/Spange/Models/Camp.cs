using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spange.Models
{
    [Table("Camps")]
    public class Camp
    {
        [Key]
        public int CampId { get; set; }

        [ForeignKey("PitchCampId")]
        public int PitchCampId { get; set; }

        public string Location { get; set; }
        public string CampDescription { get; set; }
        public int Fire { get; set; }
        public double CampPrice { get; set; }
        public string BedDescription { get; set; }
        public int WaterProof { get; set; }
        public int Thieves { get; set; }
        public int Public { get; set; }
    }
}