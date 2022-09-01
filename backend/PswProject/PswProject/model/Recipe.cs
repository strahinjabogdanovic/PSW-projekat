using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.model
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdR { get; set; }
        public string Medicine { get; set; }
        public string Quantity { get; set; }
        public string Instructions { get; set; }

        public Recipe() { }

        public Recipe(int idR, string medicine, string quantity, string instructions)
        {
            IdR = idR;
            Medicine = medicine;
            Quantity = quantity;
            Instructions = instructions;
        }

    }
}
