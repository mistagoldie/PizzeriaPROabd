using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class Stanowisko
    {
        public Stanowisko()
        {
            Pracownik = new HashSet<Pracownik>();
        }

        public int IdStanowisko { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Pracownik> Pracownik { get; set; }
    }
}
