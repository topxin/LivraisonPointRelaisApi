using System;

namespace HistoriqueAffectation.Model.Entites
{
    public class Produit
    {
        public Guid Id { get; set; }
        public string NumeroCommande { get; set; }
        public string SiteMarchandise { get; set; }
        public string Nom { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Livraison Livraison{ get; set; }
    }
}
