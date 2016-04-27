using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spange.Models
{
    [Table("PlayerFoods")]
    public class PlayerFood
    {
        [Key]
        public int PlayerFoodId { get; set; }

        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; }

        [ForeignKey("FoodId")]
        public int FoodId { get; set; }
    }
}