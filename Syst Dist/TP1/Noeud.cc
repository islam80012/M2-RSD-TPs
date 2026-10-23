#include "Noeud.h"
#include <cstring>

Define_Module(Noeud);

void Noeud::initialize()
{
    // On vérifie si c'est le nœud n1 qui initialise le départ du jeton
    if (strcmp("n1", getName()) == 0) {
        // On crée le message "jeton" avec un compteur de tours initialisé à 0
        cMessage *msg = new cMessage("jeton");
        msg->addPar("tours") = 0; // Utilisation d'un paramètre dynamique pour compter les tours

        EV << "n1 envoie le jeton pour la première fois.\n";
        send(msg, "out");
    }
}

void Noeud::handleMessage(cMessage *msg)
{
    // Vérifier si le message reçu est bien le jeton
    if (strcmp(msg->getName(), "jeton") == 0) {

        // Si c'est le nœud n1 qui reçoit le jeton de la part de n5
        if (strcmp("n1", getName()) == 0) {
            // Récupérer et incrémenter le compteur de tours
            int tours = msg->par("tours");
            tours++;
            msg->par("tours") = tours;

            EV << "n1 a reçu le jeton. Tour complet numéro : " << tours << "\n";

            // Condition d'arrêt après 3 tours complets
            if (tours >= 3) {
                EV << "3 tours complets atteints. Arrêt du jeton par n1.\n";
                delete msg; // On supprime le message pour terminer
                return;
            }
        }

        // Faire circuler le jeton vers le nœud suivant
        send(msg, "out");
    } else {
        // Sécurité pour tout autre type de message inattendu
        delete msg;
    }
}
