using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieEntity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieUI.Controllers
{
    public class UserController : Controller
    {
        IConfiguration configuration;
        public UserController(IConfiguration configuration1)
        {
            configuration = configuration1;
        }
        public async Task<IActionResult> ShowUserDetails()
        {
            //fetch API, AXIOS API,HTTPClient
            //HTTP Req/response
            //using System.Net.Http.HTTPClient
            using (HttpClient client = new HttpClient())
            {
                //API URL:http://localhost:18518/api/User/SelectUsers
                string endpoint = configuration["WebApiURL"] + "User/SelectUsers";
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<List<UserModel>>(result);
                        return View(userModel);
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserModel userModel)
        {
            using (HttpClient client = new HttpClient())
            {
                //API URL:http://localhost:18518/api/User/Register
                StringContent body = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endpoint = configuration["WebApiURL"] + "User/Register";
                using (var response = await client.PostAsync(endpoint, body))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Registred Successfully..!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Sorry..please Register again!!";
                    }
                }
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int userId)
        {
            string URL = configuration["WebApiURL"] + "User/findUserById?Id=" + userId;
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(URL))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(userModel);
                    }
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> EditUser(UserModel userModel)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
            string endpoint = configuration["WebApiURL"] + "User/EditUser";
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.PutAsync(endpoint, body))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "User Updated Successfully..!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Soory.. Unable To Register..!!";
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteUsers()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUsers(UserModel userModel)
        {
            string endpoint = configuration["WebApiURL"] + "User/DeleteUser?userId=" + userModel.UserId;
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowUserDetails", "User");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "User Not Deleted";
                    }
                }
            }
            return View();
        }


    }


};

