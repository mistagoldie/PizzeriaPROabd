using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class NapojZamowienie
    {
        public int IdZamowienie { get; set; }
        public int IdNapoj { get; set; }

        public virtual Napoj IdNapojNavigation { get; set; }
        public virtual Zamowienie IdZamowienieNavigation { get; set; }
    }
}
