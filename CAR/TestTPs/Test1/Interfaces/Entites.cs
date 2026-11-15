using System;

namespace Interfaces
{
    // Objets échangés entre le serveur et le client : passés PAR VALEUR => [Serializable]

    [Serializable]
    public class CaisseSociale
    {
        public int Code { get; set; }
        public string Designation { get; set; }
        public string Type { get; set; }          // CNAS, CASNOS ou CNR
        public int NbAdherent { get; set; }
        public string Adresse { get; set; }
        public DateTime DateCreation { get; set; }
    }

    [Serializable]
    public class AdherentInfo
    {
        public int Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNais { get; set; }
        public int Code { get; set; }             // clé étrangère vers SOCIALE
    }
}
