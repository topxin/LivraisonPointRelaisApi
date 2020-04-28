using System;

namespace HistoriqueAffectation.Model.Entites
{
    public class Livraison
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid IdProduit { get; set; }
        public Guid IdPointRelais { get; set; }
        public Produit Produit { get; set; }
        public PointRelais PointRelais { get; set; }
    }
}