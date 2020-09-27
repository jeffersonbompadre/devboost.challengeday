using Flunt.Notifications;
using MongoDB.Bson;
using System;

namespace devboost.challengeday.Domain.Models
{
    public abstract class Entidade:Notifiable
    {
        public Guid Id { get; protected set; }

        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Validate();
    }
}
