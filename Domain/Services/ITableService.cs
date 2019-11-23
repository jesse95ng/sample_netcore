using sample_netcore.Models.Entities;
using System;
using System.Collections.Generic;

namespace sample_netcore.Domain.Services
{
    /// <summary>
    /// TableService interface
    /// </summary>
    public interface ITableService
    {
        /// <summary>
        /// Gets all table.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Table> GetAllTable();

        /// <summary>
        /// Gets the table by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Table GetTableById(Guid id);

        /// <summary>
        /// Creates the table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns></returns>
        Table CreateTable(Table table);

        /// <summary>
        /// Updates the table.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="table">The table.</param>
        /// <returns></returns>
        Table UpdateTable(Guid id, Table table);
    }
}
