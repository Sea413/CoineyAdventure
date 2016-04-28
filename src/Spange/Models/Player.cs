using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spange.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public string Name { get; set; }
        public string ImgLink { get; set; }
        public int Appeal { get; set; }
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public int Satiation { get; set; }
        public int Sleep { get; set; }
        public double Spange { get; set; }

        [NotMapped]
        public virtual ICollection<Gear> Inventory { get; set; }

        public virtual ICollection<PitchCamp> PitchCamps { get; set; }
        public virtual ICollection<ClaimSpot> ClaimSpots { get; set; }
        public virtual ICollection<PlayerFood> PlayerFoods { get; set; }
        public virtual ICollection<Drug> Drugs { get; set; }
    }
}