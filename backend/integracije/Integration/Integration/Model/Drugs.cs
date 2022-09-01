using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Model
{
    public class Drugs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdL { get; set; }
        public string Medicine { get; set; }
        public string Quantity { get; set; }
        public int Mgs { get; set; }

        public Drugs(int idL, string medicine, string quantity, int mgs)
        {
            IdL = idL;
            Medicine = medicine;
            Quantity = quantity;
            Mgs = mgs;
        }
    }
}
