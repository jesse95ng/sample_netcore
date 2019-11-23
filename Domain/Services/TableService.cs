using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using sample_netcore.Domain.Validation;
using sample_netcore.Models.Context;
using sample_netcore.Models.Entities;

namespace sample_netcore.Domain.Services
{
    /// <summary>
    /// Table service
    /// </summary>
    /// <seealso cref="sample_netcore.Services.ITableService" />
    public class TableService : ITableService
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly SampleDbContext _dbContext;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public TableService(SampleDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext.ThrowIfNull(nameof(dbContext));
            _mapper = mapper.ThrowIfNull(nameof(mapper));
        }

        /// <summary>
        /// Creates the table.
        /// </summary>
        /// <param name="table">The table.</param>
        public Table CreateTable(Table table)
        {
            try
            {
                _dbContext.Tables.Add(table);
                _dbContext.SaveChanges();
                return table;
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets all table.
        /// </summary>
        public IEnumerable<Table> GetAllTable()
        {
            try
            {
                var x = _dbContext.Tables
                    .OrderBy(t => t.Id)
                    .ToList();
                return x;
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets the table by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public Table GetTableById(Guid id)
        {
            
            try
            {
                return _dbContext.Tables
                .FirstOrDefault(t => t.Id == id);
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Updates the table.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="table">The table.</param>
        public Table UpdateTable(Guid id, Table table)
        {
            try
            {
                var tableInDb = _dbContext.Tables.SingleOrDefault(t => t.Id == id);
                if (tableInDb != null)
                {
                    _mapper.Map(table, tableInDb);
                    table.Id = tableInDb.Id;
                    _dbContext.SaveChanges();
                }
                return table;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
