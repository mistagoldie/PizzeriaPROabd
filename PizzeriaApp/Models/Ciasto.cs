using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class Ciasto
    {
        public Ciasto()
        {
            PizzaCiasto = new HashSet<PizzaCiasto>();
        }

        public int IdCiasto { get; set; }
        public string Nazwa { get; set; }
        public float Cena { get; set; }

        public virtual ICollection<PizzaCiasto> PizzaCiasto { get; set; }
    }
}
