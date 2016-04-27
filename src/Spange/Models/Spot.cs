using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spange.Models
{
    [Table("Spots")]
    public class Spot
    {
        [Key]
        public int SpotId { get; set; }

        [ForeignKey("ClaimSpotId")]
        public int ClaimSpotId { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }
        public string ImgLink { get; set; }
        public int SpangeyPockets { get; set; }
        public int Pockets { get; set; }
    }
}