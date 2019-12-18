using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class DaneWysylki
    {
        public DaneWysylki()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdDane { get; set; }
        public int NrTelefonu { get; set; }
        public string Email { get; set; }
        public string Firma { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string IdUzytkownik { get; set; }

        public virtual Uzytkownik IdUzytkownikNavigation { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
