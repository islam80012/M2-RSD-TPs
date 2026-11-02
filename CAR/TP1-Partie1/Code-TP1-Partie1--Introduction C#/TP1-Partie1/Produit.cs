using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1
{
    public class Produit
    {
        private Object o;

        
        private int codeBarre;
        private string designation;
        private int quantité;
        private DateTime expire;
        private Categorie categorieProduit;
        private double prix;
        //_____________________________________________________________________//
        public Produit(int codeBarre, string designation, int quantité,
                       DateTime expire, Categorie categorieProduit, double prix)
        {
            this.codeBarre = codeBarre;
            this.designation = designation;
            this.quantité = quantité;
            this.expire = expire;
            this.categorieProduit = categorieProduit;
            this.prix = prix;
        }
        //_____________________________________________________________________//
        public Produit()
        {
            this.codeBarre = 0;
            this.designation = "";
            this.quantité = 0;
            this.expire = new DateTime(2021, 1, 1);
            this.categorieProduit = Categorie.Rien;
            this.prix = 0.0;
        }
        //_____________________________________________________________________//
        // Getters et Setters des attributs de la classe Produit

        public int getCodeBarre() { return this.codeBarre; }
        public void setCodeBarre(int codeBarre) { this.codeBarre = codeBarre; }

        public string getDesignation() { return this.designation; }
        public void setDesignation(string designation) { this.designation = designation; }

        public int getQuantite() { return this.quantité; }
        public void setQuantite(int quantité) { this.quantité = quantité; }

        public DateTime getExpire() { return this.expire; }
        public void setExpire(DateTime expire) { this.expire = expire; }

        public Categorie getCategorie() { return this.categorieProduit; }
        public void setCategorie(Categorie categorieProduit) { this.categorieProduit = categorieProduit; }

        public double getPrix() { return this.prix; }
        public void setPrix(double prix) { this.prix = prix; }
        //_____________________________________________________________________//
        // Propriétés des attributs de la classe Produit

        public int CodeBarre
        {
            get { return this.codeBarre; }
            set
            {
                if (((Object)value is int) && (value != 0))
                    this.codeBarre = value;
                else Console.WriteLine("Veuiller saisir un code barre correct");
            }
        }
        /*----------------------------------------------------*/
        public string Designation
        {
            get { return this.designation; }
            set { this.designation = value; }
        }
        /*----------------------------------------------------*/
        public int Quantité
        {
            get { return this.quantité; }
            set { this.quantité = value; }
        }
        /*----------------------------------------------------*/
        public DateTime Expire
        {
            get { return this.expire; }
            set
            {
                if (((Object)value is DateTime) && (value != new DateTime(1, 1, 1)))
                    this.expire = value;
                else Console.WriteLine("Veuiller saisir une categorie de produit correcte");
            }
        }

        /*----------------------------------------------------*/
        public Categorie CategorieProduit
        {
            get { return this.categorieProduit; }
            set
            {
                if (((Object)value is Enum) && (value != Categorie.Rien))
                    this.categorieProduit = value;
                else Console.WriteLine("Veuiller saisir une categorie de produit correcte");
            }
        }
        /*----------------------------------------------------*/
        public double Prix
        {
            get { return this.prix; }
            set
            {
                if (((Object)value is double) && (value != 0))
                    this.prix = value;
                else Console.WriteLine("Veuiller saisir un prix correct");
            }
        }

        //_____________________________________________________________________//
        public Object O
        {
            get { return this.o; }
            set { this.o = value; }
        }

        //_____________________________________________________________________//
        public bool egalite(Produit unProduit)
        {
            //if (this.prix == unProduit.prix) return true;
            //else return false;

            return (this.prix == unProduit.prix);
        }
        //_____________________________________________________________________//
        public String toString()
        {
            return ("Code Barre : " + this.codeBarre + "\nDésignation : " + this.designation + "\nQuantité :  " + this.quantité + "\nDate d'expiration :  " +
                    this.expire + "\nCatégorie : " + this.categorieProduit + "\nPrix : " + this.prix);

        }

        //_____________________________________________________________________//
        public void afficher()
        {
            Console.WriteLine(this.toString());
        }
        //_____________________________________________________________________//

    }
}
