namespace devboost.challengeday.Infra.DataModels
{
    using System;

    using devboost.challengeday.Domain.Enum;

    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;

    /// <summary>
    /// The Bank transaction data model.
    /// </summary>
    public class OperacaoDataModel
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
        [BsonElement("dataHora")]
        public DateTime? DataHora { get; set; }
        
        /// <summary>
        /// Gets or sets the valor.
        /// </summary>
        [BsonElement("valor")]
        public decimal Valor { get; set; }

        /// <summary>
        /// Gets or sets the tipo.
        /// </summary>
        [BsonElement("tipo")]
        public TipoTransacao Tipo { get; set; }
    }
}