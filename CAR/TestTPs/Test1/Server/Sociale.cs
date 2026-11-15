using System;
using System.Collections.Generic;
using Interfaces;

namespace Serveur
{
    // Composant Sociale : objet distant exposé au client (MarshalByRefObject + ISociale)
    // Il REQUIERT IAssure (Assurance) et IAdhere (Adherent)
    public class Sociale : MarshalByRefObject, ISociale
    {
        private readonly IAssure assure;
        private readonly IAdhere adhere;

        public Sociale(IAssure assure, IAdhere adhere)
        {
            this.assure = assure;
            this.adhere = adhere;
        }

        // Durée de vie illimitée de l'objet distant
        public override object InitializeLifetimeService()
        {
            return null;
        }

        //_____________________________________________________________________//
        public CaisseSociale RechercherCaisse(string type)
        {
            Console.WriteLine("Appel client : RechercherCaisse(" + type + ")");

            CaisseSociale c = assure.RechercherCaisse(type);

            if (c != null)   // affichage de la caisse côté serveur (console)
                Console.WriteLine("Caisse : " + c.Code + " | " + c.Designation + " | " + c.Adresse +
                                  " | " + c.NbAdherent + " adhérents | " + c.DateCreation.ToShortDateString());
            else
                Console.WriteLine("Aucune caisse de type " + type);

            return c;
        }

        //_____________________________________________________________________//
        public List<AdherentInfo> ListerAdherents(int codeCaisse)
        {
            Console.WriteLine("Appel client : ListerAdherents(" + codeCaisse + ")");

            List<AdherentInfo> tous = assure.RechercherAdherents(codeCaisse);
            return adhere.PreparerAdherents(tous, codeCaisse);
        }

        //_____________________________________________________________________//
        public AdherentInfo RechercherAdherent(int matricule)
        {
            Console.WriteLine("Appel client : RechercherAdherent(" + matricule + ")");

            AdherentInfo a = assure.RechercherAdherent(matricule);

            if (a != null)
                Console.WriteLine("Adhérent trouvé : " + a.Matricule + " | " + a.Nom + " " + a.Prenom +
                                  " | " + a.DateNais.ToShortDateString() + " | caisse " + a.Code);
            else
                Console.WriteLine("Aucun adhérent de matricule " + matricule);

            return a;
        }

        //_____________________________________________________________________//
        public int AjouterAdherent(AdherentInfo a)
        {
            Console.WriteLine("Appel client : AjouterAdherent(" + a.Matricule + ", " + a.Nom + " " + a.Prenom + ")");

            int n = assure.AjouterAdherent(a);
            Console.WriteLine(n + " adhérent(s) ajouté(s)");
            return n;
        }

        //_____________________________________________________________________//
        public int ModifierAdherent(AdherentInfo a)
        {
            Console.WriteLine("Appel client : ModifierAdherent(" + a.Matricule + ", " + a.Nom + " " + a.Prenom + ")");

            int n = assure.ModifierAdherent(a);
            Console.WriteLine(n + " adhérent(s) modifié(s)");
            return n;
        }

        //_____________________________________________________________________//
        public int SupprimerAdherent(int matricule)
        {
            Console.WriteLine("Appel client : SupprimerAdherent(" + matricule + ")");

            int n = assure.SupprimerAdherent(matricule);
            Console.WriteLine(n + " adhérent(s) supprimé(s)");
            return n;
        }
    }
}
