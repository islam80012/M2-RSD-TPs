using System.Collections.Generic;
using Interfaces;

namespace Serveur
{
    // Composant Adherent : fournit IAdhere (pour Sociale) et REQUIERT IFiltre (fournie par Affiche)
    public class Adherent : IAdhere
    {
        private readonly IFiltre filtre;      // interface requise, injectée par le constructeur

        public Adherent(IFiltre filtre)
        {
            this.filtre = filtre;
        }

        public List<AdherentInfo> PreparerAdherents(List<AdherentInfo> adherents, int codeCaisse)
        {
            List<AdherentInfo> filtres = filtre.Filtrer(adherents, codeCaisse);

            // (Dans le sujet complet, c'est ici qu'on construirait l'arbre Xml à partir de 'filtres'.
            //  Cette partie n'est pas demandée au test.)

            return filtres;
        }
    }
}
