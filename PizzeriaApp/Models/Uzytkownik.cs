using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class Uzytkownik
    {
        public Uzytkownik()
        {
            DaneWysylki = new HashSet<DaneWysylki>();
        }

        public string IdUzytkownik { get; set; }
        public string Haslo { get; set; }

        public virtual ICollection<DaneWysylki> DaneWysylki { get; set; }
    }
}
