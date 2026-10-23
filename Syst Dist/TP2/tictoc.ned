
simple Noeud
{
    parameters:
        int nb;
        double d;
    gates:
        input in;
        output out;
}

network Jeton
{
    submodules:
        n1: Noeud;
        n2: Noeud;
        n3: Noeud;
        n4: Noeud;
        n5: Noeud;
        n6: Noeud;
        n7: Noeud;
        n8: Noeud;
        n9: Noeud;
        n10: Noeud;

    connections:
        n1.out --> n2.in;
        n2.out --> n3.in;
        n3.out --> n4.in;
        n4.out --> n5.in;
        n5.out --> n6.in;
        n6.out --> n7.in;
        n7.out --> n8.in;
        n8.out --> n9.in;
        n9.out --> n10.in;
        n10.out --> n1.in;
}
