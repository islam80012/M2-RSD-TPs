#ifndef __SERVER_H_
#define __SERVER_H_

#include <omnetpp.h>
#include <vector>
using namespace omnetpp;

class Server : public cSimpleModule
{
  private:
    std::vector<int> reqParClient;   // requêtes traitées par client
    int total = 0;                   // total des requêtes traitées

  protected:
    virtual void initialize() override;
    virtual void handleMessage(cMessage *msg) override;
    virtual void finish() override;
};

#endif
