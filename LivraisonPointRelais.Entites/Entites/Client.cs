using System;
using System.Collections.Generic;
using HistoriqueAffectation.Model.Entites.Reference;

namespace HistoriqueAffectation.Model.Entites
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
