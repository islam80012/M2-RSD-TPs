#include "client.h"

Define_Module(Client);

Client::~Client()
{
    cancelAndDelete(timer);
}

void Client::initialize()
{
    d = par("d");
    timer = new cMessage("timer");
    scheduleAt(simTime() + d, timer);
}

void Client::handleMessage(cMessage *msg)
{
    int i = getIndex() + 1;

    if (msg == timer) {

        long a = intuniform(1, 100);
        long b = intuniform(1, 100);

        cMessage *req = new cMessage("requete");
        req->addPar("a") = a;
        req->addPar("b") = b;

        sendDelayed(req, exponential(0.5), "gate$o");
        nbEnvoyees++;

        EV << "Le client " << i << " envoie une requête pour le calcul de l'addition de "
           << a << " et " << b << endl;

        // prochain envoi après la période d
        scheduleAt(simTime() + d, timer);
    }
    else {
        long r = msg->par("r");
        nbRecues++;
        EV << "Client " << i << " : réponse reçue du serveur avec le résultat " << r << endl;
        delete msg;
    }
}

void Client::finish()
{
    EV << "Client " << getIndex() + 1 << " : requêtes envoyées = " << nbEnvoyees
       << ", réponses reçues = " << nbRecues << endl;
    recordScalar("requetes envoyees", nbEnvoyees);
    recordScalar("reponses recues", nbRecues);
}
