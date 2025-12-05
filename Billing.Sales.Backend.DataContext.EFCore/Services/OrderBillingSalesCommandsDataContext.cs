using Billing.Sales.Backend.DataContext.EFCore.DataContext;
using Billing.Sales.Backend.Repositories.Interfaces.OrderCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Sales.Backend.DataContext.EFCore.Services
{
    internal class OrderBillingSalesCommandsDataContext(IOptions<DBOptions> dboptions)
    : BillingSalesContext(dboptions), IOrderBillingSalesCommandDataContext
    {
        // ============================
        // CREATE
        // ============================
        public async Task AddOrderAsync(Order order)
        {
            // Primero guardamos la orden
            await Orders.AddAsync(order);
            await SaveChangesAsync();

            // Luego agregamos los detalles (si existen)
            if (order.OrderDetails != null)
            {
                foreach (var detail in order.OrderDetails)
                {
                    detail.OrderId = order.Id; // asignar el id recién generado
                    await OrderDetails.AddAsync(detail);
                }
            }
        }


        // ============================
        // DELETE
        // ============================
        public async Task DeleteOrderAsync(Order order)
        {
            var existing = await Orders.FirstOrDefaultAsync(o => o.Id == order.Id);

            if (existing == null)
                throw new Exception("Order not found");

            Orders.Remove(existing);
        }

        // ============================
        // GET ALL
        // ============================
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await Orders
                .OrderBy(o => o.Id)
                .ToListAsync();
        }

        // ============================
        // GET BY ID
        // ============================
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        // ============================
        // SAVE CHANGES
        // ============================
        public async Task SavesChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        // ============================
        // UPDATE
        // ============================
        public async Task UpdateOrderAsync(Order order)
        {
            var existing = await Orders.FirstOrDefaultAsync(o => o.Id == order.Id);

            if (existing == null)
                throw new Exception("Order not found");

            // copiar propiedades
            existing.OrderDate = order.OrderDate;
            existing.CustomerId = order.CustomerId;
            existing.InvoiceNumber = order.InvoiceNumber;
            existing.Total = order.Total;
        }
    }
}
