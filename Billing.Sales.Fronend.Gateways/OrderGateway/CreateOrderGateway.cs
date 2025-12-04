


namespace Billing.Sales.Fronend.Gateways.OrderGateway
{
    public class CreateOrderGateway(HttpClient cliente) : IOrderGateway
    {
        public async Task<int> CreateOrderAsync(CreateOrderDto orderDto)
        {
            int idOrder = 0;
            var response = await cliente.PostAsJsonAsync(EndPoints.Orders, orderDto);

            if (response.IsSuccessStatusCode) 
            {
                return await response.Content.ReadFromJsonAsync<int>();

            }
            return idOrder;

        }

        public async Task DeleteOrderAsync(int id)
        {
            var url = EndPoints.OrdersById.Replace("{id}",id.ToString());
            var response  = await cliente.DeleteAsync(url);
            if (!response.IsSuccessStatusCode) 
            {
                throw new Exception("Error al eliminaar la orden");
            }
        }

        public async Task<IEnumerable<CreateOrderDto>> GetAllOrdersAsync()
        {
            var response = await cliente.GetAsync(EndPoints.Orders);
            if (!response.IsSuccessStatusCode) 
            {
                return Enumerable.Empty<CreateOrderDto>();
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<CreateOrderDto>>(); ;
             
        }

        public async Task<CreateOrderDto> GetOrderByIdAsync(int id)
        {
            var url = EndPoints.OrdersById.Replace("{id}",id.ToString());

            var response = await cliente.GetAsync(url);
            if (!response.IsSuccessStatusCode) 
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<CreateOrderDto>();
        }

        public async Task updateOrderAsync(int OrderId, CreateOrderDto orderDto)
        {
            var url = EndPoints.OrdersById.Replace("{id}",OrderId.ToString());

            var response = await cliente.PutAsJsonAsync(url, orderDto);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al actualizar la order");
            }

        }
    }
}
