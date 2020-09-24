namespace devboost.challengeday.Infra.DataModels
{
    using System;

    using devboost.challengeday.Domain.Enum;

    /// <summary>
    /// The conta corrente data model.
    /// </summary>
    public class ContaCorrenteDataModel
    {
        /// <summary>
        /// Gets or sets the data hora.
        /// </summary>
        public DateTime DataHora { get; set; }

        /// <summary>
        /// Gets or sets the valor.
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Gets or sets the tipo.
        /// </summary>
        public TipoTransacao Tipo { get; set; }
    }
}