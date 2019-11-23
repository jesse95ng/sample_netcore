using AutoMapper;
using sample_netcore.Domain.Validation;
using sample_netcore.Models.Context;
using sample_netcore.Models.Entities;
using System;
using System.Data;

namespace sample_netcore.Domain.Services
{
    public class BillingService : IBillingService
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
        /// Initializes a new instance of the <see cref="BillingService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="mapper">The mapper.</param>
        public BillingService(SampleDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext.ThrowIfNull(nameof(dbContext));
            _mapper = mapper.ThrowIfNull(nameof(mapper));
        }

        public Order CreateOrder(Order order)
        {
            try
            {
                order.CreatedDate = DateTime.UtcNow;
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
                return order;
            }
            catch
            {
                throw new Exception();
            }
        }

        public OrderDetail CreateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _dbContext.OrderDetails.Add(orderDetail);
                _dbContext.SaveChanges();
                return orderDetail;
            }
            catch
            {
                throw new Exception();
            }
        }

        //public int GetRevenueByDay()
        //{
        //    SqlParameter[] @params =
        //    {
        //       new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output}
        //     };
        //    var procName = "spRevenueByDay";
        //    var query = "exec @returnVal=" + procName;
        //    _dbContext.Database.ExecuteSqlCommand(query, "@params");
        //    var res = @params[0].Value;
        //    var x = _dbContext.Orders.FromSql($"spRevenueByDay {DateTime.UtcNow}");
        //    return 0;
        //}
    }
}
