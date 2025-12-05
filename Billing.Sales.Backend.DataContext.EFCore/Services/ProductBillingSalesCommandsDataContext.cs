using Billing.Sales.Backend.DataContext.EFCore.DataContext;
using Billing.Sales.Backend.Repositories.Interfaces.ProductCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Sales.Backend.DataContext.EFCore.Services
{
    internal class ProductBillingSalesCommandsDataContext(IOptions<DBOptions> dboptions) :
    BillingSalesContext(dboptions), IProductBillingSalesCommandDataContext
    {
        public async Task AddProductAsync(Product product) => await AddAsync(product);


        public async Task DeleteProductAsync(Product product)
        {
            var existing = await Product.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existing == null)
                throw new Exception("Product not found");

            Product.Remove(existing);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await Product.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await Product.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task SavesChangesAsync() => await base.SaveChangesAsync();


        public async Task UpdateProductAsync(Product product)
        {
            var existing = await Product.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existing == null)
                throw new Exception("Product not found");
            existing.Name = product.Name;
            existing.Brand = product.Brand;
            existing.Presentation = product.Presentation;
            existing.Price = product.Price;
            existing.Stock = product.Stock;
        }
    }
}
