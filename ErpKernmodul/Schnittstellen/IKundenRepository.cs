using System;
using System.Collections.Generic;
using System.Text;

namespace ErpKernmodul.Schnittstellen
{
    public interface IKundenRepository
    {
        void hinzufuegen(Kunde kunde);
        List<Kunde> HoleAlleKundenMitBestellungen();
        Kunde HoleNachId(int kundenId);
        void akutualisieren();
        void loeschen(Kunde kunde);
    }
}
