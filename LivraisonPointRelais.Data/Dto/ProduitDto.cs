using System;

namespace LivraisonPointRelais.Data.Dto
{
    public class ProduitDto
    {
        public Guid Id { get; set; }
        public string NumeroCommande { get; set; }
        public string InfomationProduit{ get; set; }
        public Guid ClientId { get; set; }
    }
}