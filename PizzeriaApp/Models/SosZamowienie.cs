using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class SosZamowienie
    {
        public int IdZamowienie { get; set; }
        public int IdSos { get; set; }

        public virtual Sos IdSosNavigation { get; set; }
        public virtual Zamowienie IdZamowienieNavigation { get; set; }
    }
}
