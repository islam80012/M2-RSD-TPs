
simple Noeud
{
    gates:
        inout p[];
}


network TP3
{
  @display("bgb=362,240");
  submodules:
    noeud[10]: Noeud ;
  connections:
        noeud[0].p++ <--> noeud[1].p++;
        noeud[0].p++ <--> noeud[2].p++;

        noeud[1].p++ <--> noeud[4].p++;

        noeud[2].p++ <--> noeud[3].p++;
        noeud[2].p++ <--> noeud[5].p++;
        noeud[2].p++ <--> noeud[7].p++;

        noeud[4].p++ <--> noeud[6].p++;
        noeud[4].p++ <--> noeud[7].p++;

        noeud[5].p++ <--> noeud[8].p++;

        noeud[7].p++ <--> noeud[8].p++;
        noeud[7].p++ <--> noeud[9].p++;

        noeud[8].p++ <--> noeud[9].p++;
}
