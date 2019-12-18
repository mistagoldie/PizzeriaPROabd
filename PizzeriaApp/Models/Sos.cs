using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class Sos
    {
        public Sos()
        {
            SosZamowienie = new HashSet<SosZamowienie>();
        }

        public int IdSos { get; set; }
        public string Nazwa { get; set; }
        public float Cena { get; set; }

        public virtual ICollection<SosZamowienie> SosZamowienie { get; set; }
    }
}
