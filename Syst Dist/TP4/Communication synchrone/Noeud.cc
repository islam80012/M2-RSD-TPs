#include "Noeud.h"
#include "Addition_m.h"

Define_Module(Noeud);

void Noeud::initialize()
{
    isServer = (strcmp(getFullName(), "server") == 0);

    reqEnvoyees = 0;
    repRecues = 0;
    reqTraite = 0 ;
    isBlocked = false;
    serverBusy = false;

    if (isServer) {
        EV << "[SERVEUR] Initialisé et prêt.\n";
    }
    else {
        int clientId = getIndex();

        EV << "[CLIENT " << clientId << "] Démarrage...\n";

        Requete *req = new Requete("RequeteCalcul");
        req->setA(intuniform(0, 10));
        req->setB(intuniform(0, 10));
        req->setClientId(clientId); // Respectez la casse exacte générée par votre fichier .msg

        EV << "Le client " << clientId << " envoi une requête pour le calcul de l’addition de " << req->getA() << " et " << req->getB() << "\n";
        EV << "Le client " << clientId << " est bloqué en attente de la réponse\n";

        reqEnvoyees++;
        isBlocked = true;

        send(req, "p$o", 0);
    }
}

void Noeud::handleMessage(cMessage *msg)
{
    if (isServer) {
        // --- TRAITEMENT CÔTÉ SERVEUR ---
        if (dynamic_cast<Requete*>(msg)) {
            Requete *req = check_and_cast<Requete*>(msg);

            EV << "[SERVEUR] Réception de la requête du client " << req->getClientId() << ", traitement….\n";

            fifoQueue.push(req);

            while (!fifoQueue.empty()) {
                Requete *currentReq = check_and_cast<Requete*>(fifoQueue.front());
                fifoQueue.pop();

                int res = currentReq->getA() + currentReq->getB();
                int targetClient = currentReq->getClientId();

                Reponse *rep = new Reponse("ReponseCalcul");
                rep->setResultat(res);
                reqTraite++;
                EV << "[SERVEUR] Envoi de la réponse au client " << targetClient << "\n";


                // Utilisation de p$o avec sendDelayed
                sendDelayed(rep, exponential(1.0), "p$o", targetClient);

                delete currentReq;
            }
        }
    }
    else {
        // --- TRAITEMENT CÔTÉ CLIENT ---
        if (dynamic_cast<Reponse*>(msg)) {
            Reponse *rep = check_and_cast<Reponse*>(msg);
            int clientId = getIndex();

            repRecues++;
            isBlocked = false;

            EV << "Le client " << clientId << " est débloqué - réponse reçue du serveur avec le résultat r = "
               << rep->getResultat() << "\n";

            delete rep;

            if (reqEnvoyees < 5) {
                Requete *req = new Requete("RequeteCalcul");
                req->setA(intuniform(0, 50));
                req->setB(intuniform(0, 50));
                req->setClientId(clientId);

                EV << "Le client " << clientId << " envoi une requête pour le calcul de l’addition de "
                   << req->getA() << " et " << req->getB() << "\n";
                EV << "Le client " << clientId << " est bloqué en attente de la réponse\n";

                reqEnvoyees++;
                isBlocked = true;

                send(req, "p$o", 0);
            }
        }
    }
}

void Noeud::finish()
{
    if (!isServer) {
        int clientId = getIndex();
        recordScalar("Requetes envoyees", reqEnvoyees);
        recordScalar("Reponses reçues", repRecues);
        EV << "--- STATISTIQUES CLIENT " << clientId << " ---\n";
        EV << "Nombre de requêtes envoyées : " << reqEnvoyees << "\n";
        EV << "Nombre de réponses reçues : " << repRecues << "\n";
    }
    else {
        EV << "--- STATISTIQUES SERVEUR ---\n";
        recordScalar("Requete traité par le server ",reqTraite);
        EV << "Moyen des requetes traité par le serveur : " << reqTraite/3 << "\n";


    }
}
