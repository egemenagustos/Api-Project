using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _OurRoomsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _OurRoomsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            /* Bir istemci oluşturduk. */
            var client = _httpClientFactory.CreateClient();

            /* Listeleme işlemi yapacağımız için get metodumuzu çağırdık ve nereye istek yapacağını bildirdik. */
            var responseMessage = await client.GetAsync("http://localhost:3490/api/Room");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                /* Json Türünde gelen datayı aldık ve deserialize ettik.*/
                var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);

                return View(values);
            }
            return View();
        }
    }
}
