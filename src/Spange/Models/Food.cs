using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spange.Models
{
    [Table("Foods")]
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        [ForeignKey("PlayerFoodId")]
        public int PlayerFoodId { get; set; }

        public string Name { get; set; }
        public int HpBonus { get; set; }
        public double GutterPrice { get; set; }
    }
}