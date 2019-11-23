using sample_netcore.Models.Entities;

namespace sample_netcore.Domain.Services
{
    /// <summary>
    /// Billing service inteface
    /// </summary>
    public interface IBillingService
    {
        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        Order CreateOrder(Order order);

        /// <summary>
        /// Creates the order detail.
        /// </summary>
        /// <param name="orderDetail">The order detail.</param>
        /// <returns></returns>
        OrderDetail CreateOrderDetail(OrderDetail orderDetail);

        /// <summary>
        /// Gets the revenue by day.
        /// </summary>
        /// <returns></returns>
        //int GetRevenueByDay();
    }
}
