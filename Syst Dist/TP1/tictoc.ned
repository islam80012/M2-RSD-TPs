
simple Noeud
{
    gates:
        input in;
        output out;
}

network Tictoc
{
    submodules:
        tic: Noeud;
        toc: Noeud;
    connections:
        tic.out --> toc.in;
        tic.in <-- toc.out;
}

network Jeton
{
    submodules:
        n1: Noeud;
        n2: Noeud;
        n3: Noeud;
        n4: Noeud;
        n5: Noeud;
    connections:
        n1.out --> n2.in;
        n2.out --> n3.in;
        n3.out --> n4.in;
        n4.out --> n5.in;
        n5.out --> n1.in;
}
