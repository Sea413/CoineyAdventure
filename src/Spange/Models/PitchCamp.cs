using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spange.Models
{
    [Table("PitchCamps")]
    public class PitchCamp
    {
        [Key]
        public int PitchCampId { get; set; }

        [ForeignKey("CampId")]
        public int CampId { get; set; }

        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; }
    }
}