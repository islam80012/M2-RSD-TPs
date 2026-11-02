using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Superette
    {
        private string nom;
        private string adresse;
        private List<Produit> produits;
        //_____________________________________________________________________//

        private List<Produit> stock = new List<Produit>();
        private List<Produit> vente = new List<Produit>();

        public struct Chiffre
        {
            public Categorie categorieProduit { get;  set; }
            public double chiffre { get; set; } 
        }

        //_____________________________________________________________________//
        public Superette(string nom, string adresse, List<Produit> produits)
        {  // Constructeur avec paramètres
            this.nom = nom;
            this.adresse = adresse;
            this.produits = produits;
        }

        //_____________________________________________________________________//
        public Superette()
        {   // Constructeur vide
            this.nom = "";
            this.adresse = "";
            this.produits = new List<Produit>();
        }
        //_____________________________________________________________________//
        // Les Getters et Setters des attributs nom, adresse et produits
        public string getNom() { return this.nom; }
        public void setNom(string nom) { this.nom = nom; }

        /*--------------------------------------------------------------------*/
        public string Nom  // Propriété Nom de l'attribut nom
        {
            get { return this.nom; }
            set
            {
                if (((Object)value is string) && (value != ""))
                    this.nom = value;
                else Console.WriteLine("Veuiller saisir un nom correct");
            }
        }
        //_____________________________________________________________________//

        public string getAdresse() { return this.adresse; }
        public void setAdresse(string adresse) { this.adresse = adresse; }

        /*--------------------------------------------------------------------*/
        public string Adresse  // Propriété Adresse de l'attribut adresse
        {
            get { return this.adresse; }
            set
            {
                if (((Object)value is string) && (value != ""))
                    this.adresse = value;
                else Console.WriteLine("Veuiller saisir une adresse correcte");
            }
        }
        //_____________________________________________________________________//

        public List<Produit> getProduits() { return this.produits; }
        public void setProduits(List<Produit> produits) { this.produits = produits; }

        /*--------------------------------------------------------------------*/
        public List<Produit> Produits   // Propriété Produits de l'attribut produits
        {
            get { return this.produits; }
            set
            {
                if (((Object)value is List<Produit>) && (value != null))
                    this.produits = value;
                else Console.WriteLine("Veuiller saisir une adresse correcte");
            }
        }
        //_____________________________________________________________________//

        public Produit chercherProduit(string designation)
        {
            for (int i = 0; i < this.produits.Count; i++)
            {
                if ((this.produits[i].Designation).Equals(designation))
                {
                    return this.produits[i];
                }
            }
            return null;
        }

        //_____________________________________________________________________//

        public Produit chercherProduitAvecFind(string designation)
        {
            return this.produits.Find(prod => prod.Designation == designation);
        }

        //_____________________________________________________________________//
        public Produit chercherProduit1(string designation)
        {
            foreach (Produit p in this.produits)
            {
                if (p.Designation.Equals(designation)) { return p; }
            }
            return null;
        }

        //_____________________________________________________________________//
        public Produit chercherProduit2(string designation)   // recherche avec une requête Linq
        {
            IEnumerable<Produit> prod =
                                       from p in this.produits
                                       where p.Designation.Equals(designation)
                                       select p;
            return prod.First();
        }
        //_____________________________________________________________________//

        public Produit chercherProduit3(Object o)  // Recherhe d'un produit avec n'importe quel critère
        {
            for (int i = 0; i < this.produits.Count; i++)
            {
                if ((this.produits[i].O).Equals(o))
                { return this.produits[i]; }
            }
            return null;
        }

        //______________________________________________________________________
        public Produit chercherProduit(int codeBarre)
        {
            for (int i = 0; i < produits.Count; i++)
            {
                // Recherche d'un produit par son code barre
                if ((this.produits[i].CodeBarre).Equals(codeBarre))
                {
                    return this.produits[i];
                }
            }
            return null;
        }
        //_____________________________________________________________________//

        public Produit chercherProduitCodeBarre(int codeBarre)
        {
            // Recherche d'un produit par son code barre
            for (int i = 0; i < produits.Count; i++)
                if (this.produits[i].CodeBarre == codeBarre) return this.produits[i];
            return null;
        }
        //_____________________________________________________________________//
        // Recherche d'un produit par sa désignation

        public Produit chercherProduitCodeBarre(string designation)
        {
            for (int i = 0; i < produits.Count; i++)
                if (this.produits[i].Designation == designation) return this.produits[i];
            return null;
        }

        //_____________________________________________________________________//
        // Recherche d'un produit par n'importe quel critère et le premier trouvé
        public Produit chercherProduit(Object o)
        {
            for (int i = 0; i < produits.Count; i++)
                if (((Object)(this.produits[i].CodeBarre)).Equals(o) ||
                    ((Object)(this.produits[i].Designation)).Equals(o) ||
                    ((Object)(this.produits[i].Quantité)).Equals(o) ||
                    ((Object)(this.produits[i].Expire)).Equals(o) ||
                    ((Object)(this.produits[i].CategorieProduit)).Equals(o) ||
                    ((Object)(this.produits[i].Prix)).Equals(o))
                    return this.produits[i];
            return null;
        }

        //_____________________________________________________________________//
        // Recherche d'un produit par n'importe quel critère et la liste des produits trouvés
        public List<Produit> chercherProduitPlus(Object o)
        {
            List<Produit> ProduitsTrouvés = new List<Produit>();
            for (int i = 0; i < produits.Count; i++){
                if (((Object)(this.produits[i].CodeBarre)).Equals(o) ||
                    ((Object)(this.produits[i].Designation)).Equals(o) ||
                    ((Object)(this.produits[i].Quantité)).Equals(o) ||
                    ((Object)(this.produits[i].Expire)).Equals(o) ||
                    ((Object)(this.produits[i].CategorieProduit)).Equals(o) ||
                    ((Object)(this.produits[i].Prix)).Equals(o))

                    ProduitsTrouvés.Add(this.produits[i]);
            }
            return ProduitsTrouvés;
        }

        //_____________________________________________________________________//
        public void ajouterProduit1(Produit unProduit)
        {
            this.produits.Add(unProduit);   // La méthode Add ajoute unProduit à la fin de la liste produits
        }

        //_____________________________________________________________________//
        public void ajouterProduit2(int position, Produit unProduit)
        {
            this.produits.Insert(position, unProduit);   // La méthode Insert insère unProduit dans la liste produits à l'emplacement position
        }

        //_____________________________________________________________________//
        public void supprimerProduit(int codeBarre)
        {
            foreach (Produit p in this.produits)
            {
                if (p.CodeBarre.Equals(codeBarre)) { this.produits.Remove(p); }
            }
        }
        //_____________________________________________________________________//
        public void supprimerProduit2(int codeBarre)
        {
            produits.Remove(produits.Find(prod => prod.CodeBarre == codeBarre));
        }
        //_____________________________________________________________________//
        public void supprimerProduit(Produit unProduit)
        {
            if (chercherProduit3((Object)unProduit) != null)
                this.produits.Remove((chercherProduit3((Object)unProduit)));
            else
                Console.WriteLine("Produit inexistant .....");
        }

        //_____________________________________________________________________//
        public void modifierProduit(int codeBarre, string designation, int quantité,
                                    DateTime expire, Categorie categorieProduit, double prix)
        {
            if (chercherProduit3((Object)designation) != null)
            {
                Produit produitModifié = new Produit(codeBarre, designation, quantité, expire, categorieProduit, prix);

                // Le produit trouvé a été supprimé et on a ajouté à la place le nouveau : produitModifié
                this.produits.Remove((chercherProduit3((Object)designation)));
                this.produits.Add(produitModifié);
            }
            else
                Console.WriteLine("Produit inexistant .....");
        }
        //_____________________________________________________________________//
        public void modifierProduit1(int codeBarre, string designation, int quantité,
                       DateTime expire, Categorie categorieProduit, double prix)
        {
            Produit p = this.chercherProduit((Object)codeBarre);
            if (p != null)
            {
                p.Designation = designation;
                p.Quantité = quantité;
                p.Expire = expire;
                p.CategorieProduit = categorieProduit;
                p.Prix = prix;
            }
            else { Console.WriteLine("Produit inexistant....."); }
        }
        //_____________________________________________________________________//

        public void modifierProduit2(int codeBarre, string designation, int quantité,
                                            DateTime expire, Categorie categorieProduit, double prix)
        {
            if (chercherProduit3((Object)designation) != null)
            {
                // on a modifié tout les attributs du produit trouvé sauf la désignation qui était notre critère de recherche
                chercherProduit3((Object)designation).CodeBarre = codeBarre;
                chercherProduit3((Object)designation).Quantité = quantité;
                chercherProduit3((Object)designation).Expire = expire;
                chercherProduit3((Object)designation).CategorieProduit = categorieProduit;
                chercherProduit3((Object)designation).Prix = prix;

                //C'est une méthode déconseillé car pour modifier un attribut on sera obligé de rappeler à chaque fois la méthode : chercherProduit3
            }
            else
                Console.WriteLine("Produit inexistant .....");
        }
        //_____________________________________________________________________//

        public int nbProduit()
        {
            return this.produits.Count; //Compter le nombre deproduitd dans la liste produits
        }
        //_____________________________________________________________________//
        public List<Produit> stocker()
        {
            for (int i = 0; i < this.produits.Count; i++)
            {
                if (this.produits[i].Prix > 5000)  {
                    this.stock.Add(this.produits[i]);  }
            }
            return (this.stock);
        }
        //_____________________________________________________________________//
        public List<Produit> stockerAmélioré()
        {
            this.stock = (List<Produit>)(this.produits.Where(p => p.Prix > 5000));
            return this.stock;
        }
        //_____________________________________________________________________//
        public List<Produit> vendre()
        {
            foreach (Produit p in this.produits)
            {
                if ((p.CategorieProduit == Categorie.Cosmétique) &&
                    (p.Prix < 1000) &&
                    (p.Expire.Year == 2021))
                { this.vente.Add(p);}
            }
            return (this.vente);
        }
        //_____________________________________________________________________//
        public List<Produit> vendreAmélioré()
        {
            this.vente = (List<Produit>)(this.produits.Where(
                                        (p =>p.CategorieProduit == Categorie.Cosmétique &&
                                         p.Prix < 1000 &&
                                         p.Expire.Year == 2021)));
            return (this.vente);
        }
        //_____________________________________________________________________//
        public void sommer()
        {
            double somme = this.produits.Sum(x => x.CategorieProduit.CompareTo(Categorie.Cosmétique));
        }
        //_____________________________________________________________________//
        public List<Chiffre> calculerChiffreAffaire()
        {
            List<Chiffre> listeChiffreAffaire = new List<Chiffre>();

            var values = Enum.GetValues(typeof(Categorie));
            foreach (var cat in values)
            {
                Chiffre ch = new Chiffre();
                ch.categorieProduit = (Categorie)cat;

                double somme = this.produits.Where(p => p.CategorieProduit == ch.categorieProduit).
                               Sum(p => p.Prix * p.Quantité);

                ch.chiffre = somme;
                listeChiffreAffaire.Add(ch);
            }
            return listeChiffreAffaire;
        }
        //_____________________________________________________________________//

        public void afficher(Object liste)
        {
            if (liste is List<Produit>)
                foreach (Produit p in (List<Produit>)liste) { p.afficher(); }

            if (liste is List<Chiffre>)
                foreach (Chiffre c in (List<Chiffre>)liste)
                { Console.WriteLine(c.categorieProduit + " " + c.chiffre); }
        }
        //_____________________________________________________________________//
    }
}
