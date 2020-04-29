using System;
using System.Collections.Generic;
using LivraisonPointRelais.Model.Entites.Reference;

namespace LivraisonPointRelais.Model.Entites
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Sexe Sexe { get; set; }
        public ICollection<Produit> produits { get; set; }
    }
}
