using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spange.Models
{
    [Table("ClaimSpots")]
    public class ClaimSpot
    {
        [Key]
        public int ClaimSpotId { get; set; }

        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; }

        [ForeignKey("SpotId")]
        public int SpotId { get; set; }
    }
}