#include "Noeud.h"
#include "RoutageMsg_m.h"

Define_Module(Noeud);

void Noeud::initialize()
{
    // Le nœud 0 initie le message
    if (getIndex() == 0) {
        RoutageMsg *msg = new RoutageMsg("message_routage");
        msg->setHopCount(0); // Initialisation du nombre de sauts à 0

        int n = gateSize("p$o");
        if (n > 0) {
            int k = intuniform(0, n - 1); // Choix d'un voisin aléatoire
            EV << "Noeud 0 initie et envoie le message vers la porte " << k << "\n";
            send(msg, "p$o", k);
        }
    }
}

void Noeud::handleMessage(cMessage *msg)
{
    // Utilisation du Cast pour récupérer le message personnalisé
    RoutageMsg *m = check_and_cast<RoutageMsg *>(msg);

    // Vérifier si le nœud actuel est le destinataire (nœud 9)
    if (getIndex() == 9) {
        EV << "Destination atteinte (Noeud 9) ! Nombre de sauts effectues : " << m->getHopCount() << "\n";
        delete m; // Fin du parcours
    }
    else {
        // Incrémenter le nombre de sauts
        m->setHopCount(m->getHopCount() + 1);

        int n = gateSize("p$o");
        cGate *arrivalGate = m->getArrivalGate();
        int arrivalIndex = (arrivalGate != nullptr) ? arrivalGate->getIndex() : -1;

        // Choisir un port de sortie aléatoire (en évitant de renvoyer directement vers l'expéditeur si possible)
        int k;
        do {
            k = intuniform(0, n - 1);
        } while (n > 1 && k == arrivalIndex);

        EV << "Noeud " << getIndex() << " transfert le message via la porte " << k << "\n";
        send(m, "p$o", k);
    }
}
