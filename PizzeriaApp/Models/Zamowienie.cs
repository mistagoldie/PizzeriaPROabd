using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            NapojZamowienie = new HashSet<NapojZamowienie>();
            PracownikZamowienie = new HashSet<PracownikZamowienie>();
            SosZamowienie = new HashSet<SosZamowienie>();
            ZamowieniePizza = new HashSet<ZamowieniePizza>();
        }

        public int IdZamowienie { get; set; }
        public int RodzajPlatnosci { get; set; }
        public float Cena { get; set; }
        public DateTime Data { get; set; }
        public int DaneWysylkiIdDane { get; set; }
        public int IdPromocja { get; set; }

        public virtual DaneWysylki DaneWysylkiIdDaneNavigation { get; set; }
        public virtual Promocja IdPromocjaNavigation { get; set; }
        public virtual RodzajPlatnosci RodzajPlatnosciNavigation { get; set; }
        public virtual ICollection<NapojZamowienie> NapojZamowienie { get; set; }
        public virtual ICollection<PracownikZamowienie> PracownikZamowienie { get; set; }
        public virtual ICollection<SosZamowienie> SosZamowienie { get; set; }
        public virtual ICollection<ZamowieniePizza> ZamowieniePizza { get; set; }
    }
}
