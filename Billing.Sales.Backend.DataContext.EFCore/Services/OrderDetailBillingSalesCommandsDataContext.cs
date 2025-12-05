using Billing.Sales.Backend.DataContext.EFCore.DataContext;
using Billing.Sales.Backend.Repositories.Interfaces.OrderDetailCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Sales.Backend.DataContext.EFCore.Services
{
    internal class OrderDetailBillingSalesCommandsDataContext(IOptions<DBOptions> dboptions)
    : BillingSalesContext(dboptions), IOrderDetailBillingSalesCommandDataContext
    {

        // ============================================
        // CREATE
        // ============================================
        public async Task AddOrderDetailAsync(OrderDetail detail)
        {
            await AddAsync(detail);
        }

        // ============================================
        // DELETE
        // Como OrderDetail tiene PK compuesta, EF lo detecta
        // ============================================
        public async Task DeleteOrderDetailAsync(OrderDetail detail)
        {
            var existing = await OrderDetails.FirstOrDefaultAsync(d =>
                d.OrderId == detail.OrderId &&
                d.ProductId == detail.ProductId);

            if (existing == null)
                throw new Exception("OrderDetail not found");

            OrderDetails.Remove(existing);
        }

        // ============================================
        // GET ALL
        // ============================================
        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await OrderDetails
                .OrderBy(d => d.OrderId)
                .ThenBy(d => d.ProductId)
                .ToListAsync();
        }

        // ============================================
        // GET BY ID
        // IMPORTANTE:
        // No existe un solo "Id" en OrderDetail, es PK compuesta
        // Por eso este método no puede funcionar con un solo "id"
        //
        // => Te devuelvo null siempre, lo IDEAL es:
        // Task<OrderDetail?> GetOrderDetailByIdAsync(int orderId, int productId)
        // ============================================

        public async Task<OrderDetail?> GetOrderDetailByIdAsync(int id)
        {
            // OrderDetail NO TIENE un ID único. Devuelvo null.
            // Te recomiendo actualizar tu interfaz.
            return await Task.FromResult<OrderDetail?>(null);
        }

        // ============================================
        // SAVE CHANGES
        // ============================================
        public async Task SavesChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        // ============================================
        // UPDATE
        // ============================================
        public async Task UpdateOrderDetailAsync(OrderDetail detail)
        {
            var existing = await OrderDetails.FirstOrDefaultAsync(d =>
                d.OrderId == detail.OrderId &&
                d.ProductId == detail.ProductId);

            if (existing == null)
                throw new Exception("OrderDetail not found");

            existing.UnitPrice = detail.UnitPrice;
            existing.Quantity = detail.Quantity;
            existing.TotalPrice = detail.TotalPrice;
        }
    }
}
