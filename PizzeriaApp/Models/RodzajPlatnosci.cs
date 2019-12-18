using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class RodzajPlatnosci
    {
        public RodzajPlatnosci()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdRodzajPlatnosci { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
