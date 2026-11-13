#include "server.h"

Define_Module(Server);

void Server::initialize()
{
    reqParClient.assign(gateSize("gate"), 0);
}

void Server::handleMessage(cMessage *msg)
{
    // Traitement dans l'ordre de réception (FIFO)
    int k = msg->getArrivalGate()->getIndex();   // indice du client émetteur

    long a = msg->par("a");
    long b = msg->par("b");

    EV << "Réception de la requête du client " << k + 1 << ", traitement...." << endl;

    long r = a + b;
    reqParClient[k]++;
    total++;
    delete msg;

    cMessage *rep = new cMessage("reponse");
    rep->addPar("r") = r;

    EV << "Envoi de la réponse au client " << k + 1 << endl;
    sendDelayed(rep, exponential(0.2), "gate$o", k);
}

void Server::finish()
{
    int n = reqParClient.size();
    for (int k = 0; k < n; k++)
        EV << "Serveur : requêtes traitées pour le client " << k + 1
           << " = " << reqParClient[k] << endl;

    double moyenne = (n > 0) ? (double)total / n : 0;
    EV << "Serveur : nombre moyen de requêtes traitées par client = " << moyenne << endl;
    recordScalar("moyenne requetes par client", moyenne);
}
