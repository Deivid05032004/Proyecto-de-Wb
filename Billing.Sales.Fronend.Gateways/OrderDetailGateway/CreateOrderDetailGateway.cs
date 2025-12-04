


namespace Billing.Sales.Fronend.Gateways.OrderDetailGateway
{
    internal class CreateOrderDetailGateway(HttpClient client) : IOrderDetailGateway
    {
        public async Task<int> CreateOrderDetailAsync(CreateOrderDetailsDto detailDto)
        {
            int idOrderDetai = 0;
            var response = await client.PostAsJsonAsync(EndPoints.OrderDetail,detailDto);
            if (response.IsSuccessStatusCode) 
            {
                return await response.Content.ReadFromJsonAsync<int>();
            }
            return idOrderDetai;
        }

        public async Task DeleteOrderDetailAsync(int id)
        {
            var url = EndPoints.OrderDetailById.Replace("{id}",id.ToString());

            var reponse = await client.DeleteAsync(url);
            if (!reponse.IsSuccessStatusCode) 
            {
                throw new Exception("Error al eliminar el detalle de la orden");
            }
        }

        public async Task<IEnumerable<CreateOrderDetailsDto>> GetAllDetailsAsync()
        {
            var reponse = await client.GetAsync(EndPoints.OrderDetail);
            if (!reponse.IsSuccessStatusCode)
            {
                return Enumerable.Empty<CreateOrderDetailsDto>();
            }
            return await reponse.Content.ReadFromJsonAsync<IEnumerable<CreateOrderDetailsDto>>();
        }

        public async Task<CreateOrderDetailsDto> GetDetailById(int id)
        {
            var url = EndPoints.OrderDetailById.Replace("{id}", id.ToString());

            var reponse = await client.GetAsync(url);
            if (!reponse.IsSuccessStatusCode) 
            {
                return null;
            }
            return await reponse.Content.ReadFromJsonAsync<CreateOrderDetailsDto>();
        }

        public async Task UpdateOrderDetailAsync(int idOrderDetail, CreateOrderDetailsDto detailDto)
        {
            var url = EndPoints.OrderDetailById.Replace("{id}",idOrderDetail.ToString());

            var response = await client.PutAsJsonAsync(url, detailDto);
            if (!response.IsSuccessStatusCode) 
            {
                throw new Exception("Error al actualizar el detalle de la orden");
            }
        }
    }
}
