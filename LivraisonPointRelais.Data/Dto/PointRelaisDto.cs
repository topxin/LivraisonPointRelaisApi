using System;

namespace LivraisonPointRelais.Data.Dto
{
    public class PointRelaisDto
    {
        public Guid Id { get; set; }
        public string IdPointRelais { get; set; }
        public string LibelleCommercial { get; set; }
        public string Gestionnaire { get; set; }
    }
}