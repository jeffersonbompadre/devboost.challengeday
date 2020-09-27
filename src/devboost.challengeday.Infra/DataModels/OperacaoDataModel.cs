namespace devboost.challengeday.Infra.DataModels
{
    using devboost.challengeday.Shared.Enums;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    /// <summary>
    /// The Bank transaction data model.
    /// </summary>
    public class OperacaoDataModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>

        [BsonElement("IdConta")]
        [BsonId]
        public ObjectId Id { get; set; }
        
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

        public OperacaoDataModel(ObjectId id, DateTime? dataHora, decimal valor, TipoTransacao tipo)
        {
            Id = id;
            DataHora = dataHora;
            Valor = valor;
            Tipo = tipo;
        }
    }
}