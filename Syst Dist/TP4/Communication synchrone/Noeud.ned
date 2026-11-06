simple Noeud
{
    gates:
        inout p[];
}



network Jeton
{
  @display("bgb=362,240");
  submodules:
        server: Noeud;
        client[3]: Noeud;

  connections:
      server.p++ <--> client[0].p++;
      server.p++ <--> client[1].p++;
      server.p++ <--> client[2].p++;
}
