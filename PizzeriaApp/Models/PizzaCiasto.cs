using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class PizzaCiasto
    {
        public int IdPizza { get; set; }
        public int IdCiasto { get; set; }

        public virtual Ciasto IdCiastoNavigation { get; set; }
        public virtual Pizza IdPizzaNavigation { get; set; }
    }
}
