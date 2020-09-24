using System;

namespace devboost.challengeday.Domain.Models
{
    public class Entidade
    {
        public Guid Id { get; set; }

        protected Entidade()
        {
            Id = Guid.NewGuid();
        }
    }
}
