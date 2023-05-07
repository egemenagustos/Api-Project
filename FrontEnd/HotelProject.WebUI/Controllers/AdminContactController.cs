﻿using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            /* Bir istemci oluşturduk. */
            var client = _httpClientFactory.CreateClient();

            /* Listeleme işlemi yapacağımız için get metodumuzu çağırdık ve nereye istek yapacağını bildirdik. */
            var responseMessage = await client.GetAsync("http://localhost:3490/api/Contact");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:3490/api/Contact/GetContactCount");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:3490/api/SendMessage/GetSendMessageCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                /* Json Türünde gelen datayı aldık ve deserialize ettik.*/
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);

                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();

                ViewBag.contactCount = jsonData2;
                ViewBag.sendMessageCount = jsonData3;

                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> SendBox()
        {
            /* Bir istemci oluşturduk. */
            var client = _httpClientFactory.CreateClient();

            /* Listeleme işlemi yapacağımız için get metodumuzu çağırdık ve nereye istek yapacağını bildirdik. */
            var responseMessage = await client.GetAsync("http://localhost:3490/api/SendMessage");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                /* Json Türünde gelen datayı aldık ve deserialize ettik.*/
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData);

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto model)
        {
            model.SenderMail = "egemen@gmail.com";
            model.SenderName = "egemen";
            model.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("http://localhost:3490/api/SendMessage", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }

            return View();
        }

        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }

        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }

        public async Task<IActionResult> MessageDetailsBySendBox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:3490/api/SendMessage/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:3490/api/Contact/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
