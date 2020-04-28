using System;
using System.Collections.Generic;

namespace HistoriqueAffectation.Model.Entites
{
    public class PointRelais
    {
        public Guid Id { get; set; }
        public string IdPointRelais { get; set; }
        public string LibelleCommercial { get; set; }
        public string Gestionnaire { get; set; }
        public IEnumerable<Livraison> Livraisons { get; set; }
    }
}