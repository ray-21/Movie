using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieEntity;
using MovieEntity.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieUI.Controllers
{
    public class ThreaterController : Controller
    {
        IConfiguration _configuration;

        public ThreaterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> ShowThreater()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "T/selectThreater";

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        var thetreModel = JsonConvert.DeserializeObject<List<ThreaterModel>>(data);
                        return View(thetreModel);
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddThetre()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddThreater(ThreaterModel threaterModel)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(threaterModel), Encoding.UTF8, "application/json");
            string endpoint = _configuration["WebApiURL"] + "Threater/addThreater";
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(endpoint, body))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Threater Added Successfully..!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Soory.. Unable To Add Threater..!!";
                    }
                }
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateThreater(int id)
        {
            string URL = _configuration["WebApiURL"] + "Threater/fetchthreater?id=" + id;
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URL))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        ThreaterModel threaterModel = JsonConvert.DeserializeObject<ThreaterModel>(body);
                        return View(threaterModel);
                    }
                }
            }
            return RedirectToAction("ShowThreater", "Threater");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateThere(ThreaterModel threaterModel)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(threaterModel), Encoding.UTF8, "application/json");
            string URL = _configuration["WebApiURL"] + "Threater/editthreater";
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.PutAsync(URL, body))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowThreater", "Threater");
                    }
                }
            }
            return RedirectToAction("ShowThreater", "Threater");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteThreater(int id)
        {
            string endpoint = _configuration["WebApiURL"] + "Threater/deletethreater?id=" + id;
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowThreater", "Threater");
                    }
                }
            }
            return RedirectToAction("ShowThreater", "Threater");
        }
    }
}

