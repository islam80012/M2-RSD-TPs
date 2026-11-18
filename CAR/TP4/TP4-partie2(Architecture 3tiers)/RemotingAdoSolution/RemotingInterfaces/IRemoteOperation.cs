
using System.Data;

namespace RemotingInterface
{
    public interface IRemoteOperation
    {
        DataTable Afficher();

        int Ajouter(int matricule, string nom, string prenom);

        int Supprimer(int matricule);

        int Modifier(int matricule, string nom, string prenom);

        DataTable Rechercher(int matricule);
    }
}
