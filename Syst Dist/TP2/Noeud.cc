
#include "Noeud.h"
#include <cstring>

Define_Module(Noeud);

void Noeud::initialize()
{
    nbr = par("nb").intValue();
    d = par("d").doubleValue();
    compteur = 0;

    if (strcmp("n1", getName()) == 0) {
        cMessage *timer = new cMessage("timer");
        scheduleAt(simTime() + d, timer);
    }
}

void Noeud::handleMessage(cMessage *msg)
{
    if (msg->isSelfMessage()) {
        delete msg;

        if (compteur < nbr) {
            cMessage *jeton = new cMessage("jeton");
            send(jeton, "out");
            compteur++;

            if (compteur < nbr) {
                cMessage *timer = new cMessage("timer");
                scheduleAt(simTime() + d, timer);
            }
        }
    }
    else {
        EV << "Le message " << msg->getName()
           << " est recu par " << getName() << endl;

        if (strcmp("n10", getName()) == 0) {
            delete msg;
        }
        else {
            send(msg, "out");
        }
    }
}
