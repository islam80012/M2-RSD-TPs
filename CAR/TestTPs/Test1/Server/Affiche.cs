using System.Collections.Generic;
using Interfaces;

namespace Serveur
{
    // Composant Affiche : fournit IFiltre
    // Extrait uniquement les adhérents relatifs à la caisse demandée
    public class Affiche : IFiltre
    {
        public List<AdherentInfo> Filtrer(List<AdherentInfo> adherents, int codeCaisse)
        {
            List<AdherentInfo> resultat = new List<AdherentInfo>();
            foreach (AdherentInfo a in adherents)
            {
                if (a.Code == codeCaisse) resultat.Add(a);
            }
            return resultat;
        }
    }
}
