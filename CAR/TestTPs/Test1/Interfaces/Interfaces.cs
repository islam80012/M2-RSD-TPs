using System.Collections.Generic;

namespace Interfaces
{
    // Fournie par le composant Assurance, requise par Sociale
    public interface IAssure
    {
        CaisseSociale RechercherCaisse(string type);
        List<AdherentInfo> RechercherAdherents(int codeCaisse);
        AdherentInfo RechercherAdherent(int matricule);

        // CRUD : renvoient le nombre de lignes touchées (ExecuteNonQuery)
        int AjouterAdherent(AdherentInfo a);
        int ModifierAdherent(AdherentInfo a);
        int SupprimerAdherent(int matricule);
    }

    // Fournie par le composant Adherent, requise par Sociale
    public interface IAdhere
    {
        List<AdherentInfo> PreparerAdherents(List<AdherentInfo> adherents, int codeCaisse);
    }

    // Fournie par le composant Affiche, requise par Adherent
    public interface IFiltre
    {
        List<AdherentInfo> Filtrer(List<AdherentInfo> adherents, int codeCaisse);
    }

    // Interface distante : c'est ce que le CLIENT voit (Remoting)
    public interface ISociale
    {
        CaisseSociale RechercherCaisse(string type);
        List<AdherentInfo> ListerAdherents(int codeCaisse);

        // Charge un adhérent par son matricule (champs de modification)
        AdherentInfo RechercherAdherent(int matricule);

        // CRUD adhérents (appelés depuis le client)
        int AjouterAdherent(AdherentInfo a);
        int ModifierAdherent(AdherentInfo a);
        int SupprimerAdherent(int matricule);
    }
}
