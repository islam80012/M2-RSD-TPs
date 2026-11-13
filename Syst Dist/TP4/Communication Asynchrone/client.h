#ifndef __CLIENT_H_
#define __CLIENT_H_

#include <omnetpp.h>
using namespace omnetpp;

class Client : public cSimpleModule
{
  private:
    cMessage *timer = nullptr;   // timer pour l'envoi périodique
    simtime_t d;                 // période d'envoi (paramètre)
    int nbEnvoyees = 0;          // requêtes envoyées
    int nbRecues = 0;            // réponses reçues

  protected:
    virtual void initialize() override;
    virtual void handleMessage(cMessage *msg) override;
    virtual void finish() override;

  public:
    virtual ~Client();
};

#endif
