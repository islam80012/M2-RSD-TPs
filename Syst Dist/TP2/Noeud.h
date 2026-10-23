#ifndef NOEUD_H_
#define NOEUD_H_

#include <omnetpp.h>

using namespace omnetpp;

class Noeud : public cSimpleModule
{
  private:
       int nbr;
       int compteur;
       double d;
  protected:
       void initialize() override;
       void handleMessage(cMessage *msg) override;
};

#endif
