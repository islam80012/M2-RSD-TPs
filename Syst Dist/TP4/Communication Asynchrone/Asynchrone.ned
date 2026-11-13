simple Client
{
    parameters:
        double d @unit(s);   // période d'envoi des requêtes
    gates:
        inout gate;
}

simple Server
{
    parameters:
    gates:
        inout gate[];
}

network Tp4Async
{
    submodules:
        server: Server {
            @display("p=250,120");
        }
        client[3]: Client;
    connections:
        for i=0..2 {
            server.gate++ <--> { delay = 10ms; } <--> client[i].gate;
        }
}