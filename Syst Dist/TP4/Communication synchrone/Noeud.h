#ifndef NOEUD_H_
#define NOEUD_H_

#include <omnetpp.h>
#include <queue>

using namespace omnetpp;

class Noeud : public cSimpleModule
{
  private:
    bool isServer;

    // Variables pour les statistiques et le suivi (Client)
    int reqEnvoyees;
    int repRecues;
    int reqTraite;
    bool isBlocked;

    // Variables pour le serveur (File d'attente FIFO)
    std::queue<cMessage*> fifoQueue;
    bool serverBusy;

  protected:
    void initialize() override;
    void handleMessage(cMessage *msg) override;
    void finish() override; // Pour afficher les statistiques à la fin
};

#endif
