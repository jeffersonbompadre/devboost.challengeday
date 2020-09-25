namespace devboost.challengeday.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using devboost.challengeday.Domain.Models;

    /// <summary>
    /// The OperacaoRepository interface.
    /// </summary>
    public interface IOperacaoRepository
    {
        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="Task{List}"/>.
        /// </returns>
        Task<List<Operacao>> GetAll();

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task{List}"/>.
        /// </returns>
        Task<Operacao> GetById(Guid id);

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="operacao">
        /// The operacao.
        /// </param>
        /// <returns>
        /// The <see cref="Task{Operacao}"/>.
        /// </returns>
        Task<Operacao> Save(Operacao operacao);
    }
}