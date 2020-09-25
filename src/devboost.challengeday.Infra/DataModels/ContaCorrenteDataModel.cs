namespace devboost.challengeday.Infra.DataModels
{
    using System;

    using devboost.challengeday.Domain.Enum;

    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;

    /// <summary>
    /// The conta corrente data model.
    /// </summary>
    public class ContaCorrenteDataModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>

        [BsonElement("id")]
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }
        
        /// <summary>
        /// Gets or sets the data hora.
        /// </summary>
        [BsonElement]
        public DateTime? DataHora { get; set; }
        
        /// <summary>
        /// Gets or sets the valor.
        /// </summary>
        [BsonElement]
        public decimal Valor { get; set; }

        /// <summary>
        /// Gets or sets the tipo.
        /// </summary>
        [BsonElement]
        public TipoTransacao Tipo { get; set; }
    }
}