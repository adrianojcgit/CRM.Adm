using System;

namespace CRM.Adm.Domain.Entities
{
    public abstract class BaseDomainCRM
    {
        public int Id { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime? DataAtualizacao { get; protected set; }
    }
}
