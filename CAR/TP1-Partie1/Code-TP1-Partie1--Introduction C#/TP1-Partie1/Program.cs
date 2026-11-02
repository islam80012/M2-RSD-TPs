using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Program
    {
       public static void Main(string[] args)
        {

            Console.WriteLine("Hello world ........");
            
            Produit p1 = new Produit(1, "Bomo", 5, new DateTime(2019, 10, 17), Categorie.Alimentaire, 70);
            Console.WriteLine("Produit P1 ........ :");
            p1.afficher(); Console.WriteLine();
            
            Produit p2 = new Produit();           
            p2.setCodeBarre(2);
            p2.setDesignation("Isis");
            p2.setQuantite(20);
            p2.setExpire(new DateTime(2019,10,22));
            p2.setCategorie(Categorie.Detergent);
            p2.setPrix(180); Console.WriteLine();

            Console.WriteLine("Produit P2 ........ :");
            p2.afficher();

            Produit p6 = new Produit();
            p6.CodeBarre=6;
            p6.Designation="Isis";
            p6.Quantité=2;
            p6.Expire=new DateTime(2022, 10, 11);
            p6.CategorieProduit=Categorie.Vestimentaire;
            p6.Prix=99;


            Console.WriteLine("getteur1 : " + p2.getCodeBarre());
            p2.CodeBarre = 17;
            Console.WriteLine("getteur2 : "+p2.getCodeBarre());
            Console.WriteLine("propriété : "+p2.CodeBarre);
            Console.WriteLine();

            List<Produit> liste = new List<Produit>();
            liste.Add(p1); liste.Add(p2);


            Produit p3 = new Produit(3, "Shampoo", 15, new DateTime(2022, 9, 7), Categorie.Cosmétique, 100);
            Produit p4 = new Produit(4, "Parfum : la vie est belle", 6, new DateTime(2021, 10, 4), Categorie.Cosmétique, 15000);
            Produit p5 = new Produit(5, "Crème : nivea", 20, new DateTime(2023, 11, 5), Categorie.Cosmétique, 300);
            Produit p11 = new Produit(11, "Crème : gommage", 50, new DateTime(2025, 7, 31), Categorie.Cosmétique, 40);


            List<Produit> listeCosmétique = new List<Produit>();
            listeCosmétique.Add(p3);
            listeCosmétique.Add(p4);
            listeCosmétique.Add(p5);
            listeCosmétique.Add(p11);


            Superette S1 = new Superette("Uno","Alger",liste);

            Superette S2 = new Superette("Galaxy", "Ain naadja", listeCosmétique);



            Console.WriteLine("Recherche par Code barre : ");
            Produit p7 = S1.chercherProduit((Object) 17);
            p7.afficher(); Console.WriteLine();

            Console.WriteLine("Recherche par Désignation : ");
            Produit p8 = S2.chercherProduit((Object) "Parfum : la vie est belle");
            p8.afficher(); Console.WriteLine();

            Console.WriteLine("Recherche par Quantité : ");
            Produit p9 = S2.chercherProduit((Object) 20);
            p9.afficher(); Console.WriteLine();

            Console.WriteLine("Recherche par Date : ");
            Produit p10 = S2.chercherProduit((Object) new DateTime(2023, 11, 5));
            p10.afficher(); Console.WriteLine();

            Console.WriteLine("Recherche par Catégorie : ");
            Produit p12 = S2.chercherProduit((Object) Categorie.Cosmétique);
            p12.afficher(); Console.WriteLine();

            Console.WriteLine("Recherche par Prix : ");
            Produit p13 = S2.chercherProduit((Object) 40.0);
            p13.afficher(); Console.WriteLine();


            // A compléter par des exemples pour tester toutes les méthodes des classes Produit et Superette ............


            Console.ReadKey();
        }
    }
}
