using System;
using HistoriqueAffectation.Model.Entites.Reference;

namespace HistoriqueAffectation.Data.Dto
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sexe { get; set; }
    }
}